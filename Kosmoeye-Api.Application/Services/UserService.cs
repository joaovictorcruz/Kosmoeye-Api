using Kosmoeye_Api.Application.DTOS.Users.Create;
using Kosmoeye_Api.Application.DTOS.Users.Kosmoeye_Api.Application.DTOS.Users;
using Kosmoeye_Api.Application.DTOS.Users.Update;
using Kosmoeye_Api.Application.UseCases.Users;
using Kosmoeye_API.Api.Services.Interfaces;

namespace Kosmoeye_API.Api.Services
{
    public class UserService : IUserService
    {
        private readonly CreateUserHandler _createHandler;
        private readonly GetAllUsersHandler _getAllUsersHandler;
        private readonly GetUserByIdHandler _getUserByIdHandler;
        private readonly UpdateUserHandler _updateHandler;
        private readonly ChangePasswordHandler _changePasswordHandler;
        private readonly DeleteUserHandler _deleteHandler;

        public UserService(
            CreateUserHandler createHandler,
            GetAllUsersHandler getAllUsersHandler,
            GetUserByIdHandler getUserByIdHandler,
            UpdateUserHandler updateHandler,
            ChangePasswordHandler changePasswordHandler,
            DeleteUserHandler deleteHandler)
        {
            _createHandler = createHandler;
            _getAllUsersHandler = getAllUsersHandler;
            _getUserByIdHandler = getUserByIdHandler;
            _updateHandler = updateHandler;
            _changePasswordHandler = changePasswordHandler;
            _deleteHandler = deleteHandler;
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserComand command)
            => await _createHandler.Handle(command);

        public async Task<List<GetUserResponse>> GetAllUsersAsync()
        {
            var users = await _getAllUsersHandler.Handle();

            return users.Select(u => new GetUserResponse
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Bio = u.Bio,
                PictureUrl = u.PictureUrl
            }).ToList();
        }

        public async Task<GetUserResponse> GetUserByIdAsync(Guid id)
        {
            var user = await _getUserByIdHandler.Handle(id);

            return new GetUserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Bio = user.Bio,
                PictureUrl = user.PictureUrl
            };
        }

        public async Task UpdateUserAsync(UpdateUserCommand command)
            => await _updateHandler.Handle(command);

        public async Task ChangePasswordAsync(ChangePasswordCommand command)
            => await _changePasswordHandler.Handle(command);

        public async Task DeleteUserAsync(Guid id)
            => await _deleteHandler.Handle(id);
    }
}
