using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyaiCoach.Application.Features.Command.AiCommand.ChatConversationAi;
using MyaiCoach.Application.Features.Command.AiCommand.NutritionConversationAsync;
using MyaiCoach.Domain.Role;

namespace MyaiCoach.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class AiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AiController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkoutAi([FromHeader]string Aiservice, [FromBody] WokoutConversationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            WokoutConversationResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNutritionAi([FromHeader] string Aiservice, [FromBody] NutritionConversationAsyncRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            NutritionConversationAsyncResponse response = await _mediator.Send(request);

            return Ok(response.DietProgramViewDtos);
        }
    }



}