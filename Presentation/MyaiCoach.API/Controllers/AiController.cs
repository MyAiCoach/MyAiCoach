using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyaiCoach.Application.Features.Command.AiCommand.ChatConversationAi;
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
        public async Task<IActionResult> ChatConversation([FromBody] ChatConversationAiRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            ChatConversationAiResponse response = await _mediator.Send(request);

            return Ok(response.ProgramViewDtos);
        }
    }



}