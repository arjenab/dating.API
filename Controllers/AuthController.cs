using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
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
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            // Validate request

            userForRegisterDto.Username =  userForRegisterDto.Username.ToLower();
            if(await _Repo.UserExists(userForRegisterDto.Username))
                return BadRequest("User exists");
            var userToCreate = new User
            {
                UserName = userForRegisterDto.Username
            };

            var createdUser = await _Repo.Register(userToCreate, userForRegisterDto.Password);
            return StatusCode(201);
        }
    }
}