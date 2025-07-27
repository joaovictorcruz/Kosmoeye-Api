using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Kosmoeye_Api.Application.DTOS.Auth;
using Kosmoeye_Api.Application.Services;
using Kosmoeye_Api.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Kosmoeye_Api.Application.UseCases.Auth
{
    public class LoginUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenGenerator _jwtService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public LoginUserHandler(IUserRepository userRepository, TokenGenerator jwtService, IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<LoginUserResponse> Handle(LoginUserCommand command, string ipAddress)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);

            if (user == null || !VerifyPassword(command.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Email ou senha inválidos.");
            }

            var jwtToken = _jwtService.GenerateJwtToken(user);

            var refreshToken = _jwtService.GenerateRefreshToken(ipAddress);
            refreshToken.UserId = user.Id;

            await _refreshTokenRepository.AddAsync(refreshToken);

            return new LoginUserResponse
            {
                JwtToken = jwtToken,
                RefreshToken = refreshToken.Token,
                ExpiresAt = refreshToken.ExpiresAt
            };
        }

        private bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }

    }
}
