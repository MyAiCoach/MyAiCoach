using MediatR;
using MyaiCoach.Application.Services;
using MyaiCoach.Domain.Dtos.Ai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Features.Command.AiCommand.ChatConversationAi
{
    public class WokoutConversationHandler : IRequestHandler<WokoutConversationRequest, WokoutConversationResponse>
    {
        private readonly IAiServices _aiServices;

        public WokoutConversationHandler(IAiServices aiServices)
        {
            _aiServices = aiServices;
        }

        public async Task<WokoutConversationResponse> Handle(WokoutConversationRequest request, CancellationToken cancellationToken)
        {

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

            return new()
            {
                ProgramViewDtos = response
            };
        }
    }
}
