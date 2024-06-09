using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MyaiCoach.Application.Services;
using MyaiCoach.Domain.Dtos.Ai;
using MyaiCoach.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Features.Command.AiCommand.ChatConversationAi
{
    public class WokoutConversationHandler : IRequestHandler<WokoutConversationRequest, WokoutConversationResponse>
    {
        private readonly IAiServices _aiServices;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserExerciseService _userExerciseService;

        public WokoutConversationHandler(IAiServices aiServices, IHttpContextAccessor httpContextAccessor, IUserExerciseService userExerciseService)
        {
            _aiServices = aiServices;
            _httpContextAccessor = httpContextAccessor;
            _userExerciseService = userExerciseService;
        }

        public async Task<WokoutConversationResponse> Handle(WokoutConversationRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            CreateWorkoutDto createWorkoutDto = new()
            {
                Age = request.Age,
                Weight = request.Weight,
                Height = request.Height,
                WorkoutLevel = request.WorkoutLevel,
                WorkoutType = request.WorkoutType,
                WorkoutDuration = request.WorkoutDuration,
                WorkoutDayCount = request.WorkoutDayCount
            };
            var response = await _aiServices.WokoutConversationAsync(createWorkoutDto);

            var saveWorkout = await _userExerciseService.SaveWorkoutAsync(Guid.Parse(userId), response.ToList());


            return new()
            {
                IsSuccess = saveWorkout
            };
        }
    }
}
