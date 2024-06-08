using MediatR;
using MyaiCoach.Application.Services;
using MyaiCoach.Domain.Dtos.Ai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Features.Command.AiCommand.NutritionConversationAsync
{
    public class NutritionConversationAsyncHandler : IRequestHandler<NutritionConversationAsyncRequest, NutritionConversationAsyncResponse>
    {
        private readonly IAiServices _aiServices;

        public NutritionConversationAsyncHandler(IAiServices aiServices)
        {
            _aiServices = aiServices;
        }

        public async Task<NutritionConversationAsyncResponse> Handle(NutritionConversationAsyncRequest request, CancellationToken cancellationToken)
        {
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

            return new()
            {
                DietProgramViewDtos = response
            };
        }
    }
}
