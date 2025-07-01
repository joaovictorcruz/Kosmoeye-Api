using Kosmoeye_Api.Application.DTOS.Auth;
using Kosmoeye_Api.Application.DTOS.Users.Create;
using Kosmoeye_Api.Application.Services.Interfaces;
using Kosmoeye_Api.Application.UseCases.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kosmoeye_API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var result = await _authService.LoginAsync(command);
            return Ok(result);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] CreateUserComand command)
        {
            var result = await _authService.SignupAsync(command);
            return CreatedAtAction(nameof(Signup), new { id = result.Id }, result);
        }
    }
}
