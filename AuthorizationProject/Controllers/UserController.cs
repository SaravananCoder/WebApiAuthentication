using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class UserController : ControllerBase
    {

        [HttpGet]
    
        //Get Full User
        public IActionResult GetUsers()
        {
            var users = new List<object>()
            {
                new { Id = 1, Name = "Saravana", Role = "Admin" },
                new { Id = 2, Name = "Kumar", Role = "User" },
                new { Id = 3, Name = "Arun", Role = "Manager" }
            };

            return Ok(users);
        }

    }
}