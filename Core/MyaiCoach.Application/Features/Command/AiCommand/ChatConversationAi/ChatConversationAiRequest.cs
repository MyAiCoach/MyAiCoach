using MediatR;
using MyaiCoach.Domain.Dtos.Ai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Features.Command.AiCommand.ChatConversationAi
{
    public class ChatConversationAiRequest : IRequest<ChatConversationAiResponse>
    {
        public string Input { get; set; }
    }
}
