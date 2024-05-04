using MediatR;
using MyaiCoach.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Application.Features.Command.AiCommand.ChatConversationAi
{
    public class ChatConversationAiCommandHandler : IRequestHandler<ChatConversationAiRequest, ChatConversationAiResponse>
    {
        private readonly IAiServices _aiServices;

        public ChatConversationAiCommandHandler(IAiServices aiServices)
        {
            _aiServices = aiServices;
        }

        public async Task<ChatConversationAiResponse> Handle(ChatConversationAiRequest request, CancellationToken cancellationToken)
        {
            var response = await _aiServices.ConversationAsync(request.Input);

            return new()
            {
                ProgramViewDtos = response
            };
        }
    }
}
