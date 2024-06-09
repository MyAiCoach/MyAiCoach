using MediatR;
using Microsoft.AspNetCore.Http;
using MyaiCoach.Application.Services;
using MyaiCoach.Domain.Dtos.Ai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Features.Command.AiCommand.NutritionConversationAsync
{
    public class NutritionConversationAsyncHandler : IRequestHandler<NutritionConversationAsyncRequest, NutritionConversationAsyncResponse>
    {
        private readonly IAiServices _aiServices;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserNutritionService _userNutritionService;

        public NutritionConversationAsyncHandler(IAiServices aiServices, IHttpContextAccessor httpContextAccessor, IUserNutritionService userNutritionService)
        {
            _aiServices = aiServices;
            _httpContextAccessor = httpContextAccessor;
            _userNutritionService = userNutritionService;
        }

        public async Task<NutritionConversationAsyncResponse> Handle(NutritionConversationAsyncRequest request, CancellationToken cancellationToken)
        {

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            CreateNutritionDto createNutritionDto = new()
            {
                Age = request.Age,
                Weight = request.Weight,
                Height = request.Height,
                NutritionGoal = request.NutritionGoal,
                NutritionDuration = request.NutritionDuration,
                LactoseInTolerance = request.LactoseInTolerance,
                GlutenInTolerance = request.GlutenInTolerance,
                Vegan = request.Vegan
            };
            var response = await _aiServices.NutritionConversationAsync(createNutritionDto);

            var saveNutrition = await _userNutritionService.SaveNutritionAsync(Guid.Parse(userId), response.ToList());

            return new()
            {
                IsSuccess = saveNutrition
            };
        }
    }
}
