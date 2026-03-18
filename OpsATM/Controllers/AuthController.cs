using Microsoft.AspNetCore.Mvc;
using OpsATM.Application.DTOs;
using OpsATM.Application.Interface;

namespace OpsATM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            var result = await _userService.RegisterUser(dto);
            if (result == "User Already Exists")
            {
                return BadRequest("User registration failed.");
            }
            return Ok(result);
        }

        // ✅ Login User
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _userService.Login(dto);

            if (result == "Invalid")
                return Unauthorized("Invalid Email or Password");

            return Ok(result); // later will return JWT
        }
    }
}
