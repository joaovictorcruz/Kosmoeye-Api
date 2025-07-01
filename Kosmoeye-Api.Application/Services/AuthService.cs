using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Auth;
using Kosmoeye_Api.Application.DTOS.Users.Create;
using Kosmoeye_Api.Application.Services.Interfaces;
using Kosmoeye_Api.Application.UseCases.Auth;

namespace Kosmoeye_Api.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly LoginUserHandler _loginUserHandler;
        private readonly CreateUserHandler _createUserHandler;

        public AuthService(LoginUserHandler loginUserHandler, CreateUserHandler createUserHandler)
        {
            _loginUserHandler = loginUserHandler;
            _createUserHandler = createUserHandler;
        }

        public async Task<LoginUserResponse> LoginAsync(LoginUserCommand command)
        {
            return await _loginUserHandler.Handle(command);
        }

        public async Task<CreateUserResponse> SignupAsync(CreateUserComand command)
        {
            return await _createUserHandler.Handle(command);
        }
    }
}
