using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyaiCoach.Application.Services;
using MyaiCoach.Infrastructure.Services;

namespace MyaiCoach.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AiController : ControllerBase
    {
        private readonly IAiServices _aiServices;

        public AiController(IAiServices aiServices)
        {
            _aiServices = aiServices;
        }



        [HttpPost]
        public async Task<IActionResult> ChatConversation([FromBody] OpenAIRequest request)
        {
            var response = await _aiServices.ConversationAsync(request.Input);

            return Ok(response);
         }


        public class OpenAIRequest
        {
            public string Input { get; set; }
        }
    }

}