using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MyaiCoach.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "User")]
        public string GetUser()
        {
            return "You hit me!";
        }

        [HttpGet]
        [Authorize(Roles = "Bugra")]
        public string GetBugra()
        {
            return "You hit me!";
        }
    }

}
