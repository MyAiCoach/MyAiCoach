using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyaiCoach.Application.Services;
using MyaiCoach.Domain.Dtos;
using Newtonsoft.Json;

namespace MyaiCoach.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserExerciseController : ControllerBase
    {
        private readonly IUserExerciseService _userExerciseService;

        public UserExerciseController(IUserExerciseService userExerciseService)
        {
            _userExerciseService = userExerciseService;
        }



        [HttpPost]
        public async Task<IActionResult> Save(string id, List<ProgramViewDto> input)
        {

            var result = await _userExerciseService.SaveWorkoutAsync(Guid.Parse(id), input);

            return Ok(result);
        }
    }
}
