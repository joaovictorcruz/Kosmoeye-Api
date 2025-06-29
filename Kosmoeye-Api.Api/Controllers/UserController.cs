using Kosmoeye_Api.Application.DTOS.Users;
using Kosmoeye_Api.Application.UseCases.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kosmoeye_API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CreateUserHandler _createUserHandler;

        public UserController(CreateUserHandler createUserHandler)
        {
            _createUserHandler = createUserHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserComand command)
        {
            try
            {
                var result = await _createUserHandler.Handle(command);
                return CreatedAtAction(nameof(CreateUser), new { id = result.Id }, result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Erro interno no servidor." });
            }
        }
    }
}
