using Kosmoeye_Api.Application.DTOS.Auth;
using Kosmoeye_Api.Application.UseCases.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kosmoeye_API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LoginUserHandler _loginUserHandler;

        public AuthController(LoginUserHandler loginUserHandler)
        {
            _loginUserHandler = loginUserHandler;            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var result = await _loginUserHandler.Handle(command);
            return Ok(result);
        }
    }
}
