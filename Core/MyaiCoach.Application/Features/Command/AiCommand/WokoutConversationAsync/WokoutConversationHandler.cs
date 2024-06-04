using MediatR;
using MyaiCoach.Application.Services;
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
            var response = await _aiServices.WokoutConversationAsync(request.CreateWorkoutDto);

            return new()
            {
                ProgramViewDtos = response
            };
        }
    }
}
