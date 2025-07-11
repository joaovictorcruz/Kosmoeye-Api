using Kosmoeye_Api.Application.DTOS.Users.Create;
using Kosmoeye_Api.Application.DTOS.Users.Search;
using Kosmoeye_Api.Application.DTOS.Users.Update;
using Kosmoeye_Api.Application.UseCases.Users;
using Kosmoeye_API.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kosmoeye_API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;
            await _userService.UpdateUserAsync(command);
            return NoContent();
        }
        [Authorize]
        [HttpPut("{id}/change-password")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody] ChangePasswordCommand command)
        {
            command.Id = id;
            await _userService.ChangePasswordAsync(command);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchUserQuery query)
        {
            if (string.IsNullOrWhiteSpace(query.Username))
                return BadRequest(new { message = "Username é obrigatório para busca." });

            var result = await _userService.SearchUsersAsync(query);
            return Ok(result);
        }
    }
}
