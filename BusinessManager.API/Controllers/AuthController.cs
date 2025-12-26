using BusinessManager.Application.DTOs;
using BusinessManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BusinessManager.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto.Username, dto.Password);

            if (token == null)
                return Unauthorized("Invalid username or password");

            return Ok(new { token });
        }
    }
}

