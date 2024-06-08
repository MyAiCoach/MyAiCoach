using MediatR;
using MyaiCoach.Application.Features.Command.AiCommand.ChatConversationAi;
using MyaiCoach.Domain.Dtos.Ai;
using MyaiCoach.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Features.Command.AiCommand.NutritionConversationAsync
{
    public class NutritionConversationAsyncRequest : IRequest<NutritionConversationAsyncResponse>
    {

        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public NutritionGoal NutritionGoal { get; set; }
        public int NutritionDuration { get; set; }
        public bool LactoseInTolerance { get; set; }
        public bool GlutenInTolerance { get; set; }
        public bool Vegan { get; set; }
    }
}
