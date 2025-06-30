using Kosmoeye_Api.Application.DTOS.Users.Create;
using Kosmoeye_Api.Application.DTOS.Users.Update;
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
        private readonly GetAllUsersHandler _getAllUsersHandler;
        private readonly GetUserByIdHandler _getUserByIdHandler;
        private readonly UpdateUserHandler _updateUserHandler;
        private readonly ChangePasswordHandler _changePasswordHandler;
        private readonly DeleteUserHandler _deleteUserHandler;
        public UserController(CreateUserHandler createUserHandler, GetAllUsersHandler getAllUsersHandler, 
            GetUserByIdHandler getUserByIdHandler, UpdateUserHandler updateUserHandler, ChangePasswordHandler changePasswordHandler,
            DeleteUserHandler deleteUserHandler)
        {
            _createUserHandler = createUserHandler;
            _getAllUsersHandler = getAllUsersHandler;
            _getUserByIdHandler = getUserByIdHandler;
            _updateUserHandler = updateUserHandler;
            _changePasswordHandler = changePasswordHandler;
            _deleteUserHandler = deleteUserHandler;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _getAllUsersHandler.Handle();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var user = await _getUserByIdHandler.Handle(id);
                return Ok(user);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;
            await _updateUserHandler.Handle(command);
            return NoContent();
        }

        [HttpPut("{id}/change-password")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody] ChangePasswordCommand command)
        {
            command.Id = id;
            await _changePasswordHandler.Handle(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _deleteUserHandler.Handle(id);
            return NoContent();
        }

    }
}
