using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyaiCoach.Application.Repositories;
using MyaiCoach.Domain.Entities;

namespace MyaiCoach.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IAppUserRepository _appUserRepository;

        public UserController(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(string name)
        {
            var newUser = new AppUser()
            {
                Name = name,
            };

            var result = await _appUserRepository.AddAsync(newUser);
            _ = await _appUserRepository.SaveAsync();

            return Ok(result);
        }
    }
}
