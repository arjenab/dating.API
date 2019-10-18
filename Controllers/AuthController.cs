using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IAuthRepository _Repo;
        public AuthController(IAuthRepository Repo)
        {
            _Repo = Repo;

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            // Validate request

            username = username.ToLower();
            if(await _Repo.UserExists(username))
                return BadRequest("User exists");
            var userToCreate = new User
            {
                UserName = username
            };

            var createdUser = await _Repo.Register(userToCreate, password);
            return StatusCode(201);
        }
    }
}