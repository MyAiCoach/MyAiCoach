using MediatR;
using MyaiCoach.Domain.Dtos.Ai;
using MyaiCoach.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Features.Command.AiCommand.ChatConversationAi
{
    public class WokoutConversationRequest : IRequest<WokoutConversationResponse>
    {

        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public WorkoutLevel WorkoutLevel { get; set; }
        public WorkoutType WorkoutType { get; set; }

        public int WorkoutDuration { get; set; }
        public int WorkoutDayCount { get; set; }
    }
}   
