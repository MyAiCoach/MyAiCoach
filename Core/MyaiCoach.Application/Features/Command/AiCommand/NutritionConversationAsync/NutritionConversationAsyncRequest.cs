using MediatR;
using MyaiCoach.Application.Features.Command.AiCommand.ChatConversationAi;
using MyaiCoach.Domain.Dtos.Ai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Features.Command.AiCommand.NutritionConversationAsync
{
    public class NutritionConversationAsyncRequest : IRequest<NutritionConversationAsyncResponse>
    {

        public CreateNutritionDto? CreateNutritionDto { get; set; }
    }
}
