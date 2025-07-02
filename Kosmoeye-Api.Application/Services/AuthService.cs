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
        private readonly RefreshTokenHandler _refreshTokenHandler;
        private readonly RevokeRefreshTokenHandler _revokeRefreshTokenHandler;

        public AuthService(
            LoginUserHandler loginUserHandler,
            CreateUserHandler createUserHandler,
            RefreshTokenHandler refreshTokenHandler,
            RevokeRefreshTokenHandler revokeRefreshTokenHandler)
        {
            _loginUserHandler = loginUserHandler;
            _createUserHandler = createUserHandler;
            _refreshTokenHandler = refreshTokenHandler;
            _revokeRefreshTokenHandler = revokeRefreshTokenHandler;
        }

        public async Task<LoginUserResponse> LoginAsync(LoginUserCommand command, string ipAdress)
        {
            return await _loginUserHandler.Handle(command, ipAdress);
        }

        public async Task<CreateUserResponse> SignupAsync(CreateUserComand command)
        {
            return await _createUserHandler.Handle(command);
        }

        public async Task<LoginUserResponse> RefreshTokenAsync(string token, string ipAdress)
        {
            return await _refreshTokenHandler.Handle(token, ipAdress);
        }

        public async Task RevokeRefreshTokenAsync(string token, string ipAddress)
        {
            await _revokeRefreshTokenHandler.Handle(token, ipAddress);
        }
    }
}
