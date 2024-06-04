using MediatR;
using MyaiCoach.Application.Services;
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
            var response = await _aiServices.NutritionConversationAsync(request.CreateNutritionDto);

            return new()
            {
                DietProgramViewDtos = response
            };
        }
    }
}
