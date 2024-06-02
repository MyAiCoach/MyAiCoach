using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyaiCoach.Application.Services;
using MyaiCoach.Domain.Dtos;
using Newtonsoft.Json;


namespace MyaiCoach.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UserNutritionController:ControllerBase
    {
        private readonly IUserNutritionService _userNutritionService;

        public UserNutritionController(IUserNutritionService userNutritionService)
        {
            _userNutritionService= userNutritionService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(string id,List<DietProgramViewDto> input)
        {
            var result =await _userNutritionService.SaveNutritionAsync(Guid.Parse(id), input);
            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            var result =await _userNutritionService.GetNutritionProgramAsync(Guid.Parse(id));
            return Ok(result);
        }

    }
}
