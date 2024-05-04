using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyaiCoach.Application.Features.Command.AiCommand.ChatConversationAi;
using MyaiCoach.Application.Services;
using MyaiCoach.Domain.Dtos;
using MyaiCoach.Domain.Dtos.Ai;
using MyaiCoach.Infrastructure.Services;

namespace MyaiCoach.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
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
            if(request == null)
                throw new ArgumentNullException(nameof(request));

            ChatConversationAiResponse response = await _mediator.Send(request);

            return Ok(response.ProgramViewDtos);
         }

    }

}