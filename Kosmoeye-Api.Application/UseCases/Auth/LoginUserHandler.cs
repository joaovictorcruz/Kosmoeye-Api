using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Kosmoeye_Api.Application.DTOS.Auth;
using Kosmoeye_Api.Domain.Entities;
using Kosmoeye_Api.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Kosmoeye_Api.Application.UseCases.Auth
{
    public class LoginUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

    public LoginUserHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<LoginUserResponse> Handle(LoginUserCommand command)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(command.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Email ou senha inválidos");

            var token = GenerateJwtToken(user);

            return new LoginUserResponse { Token = token };
        }
        private string GenerateJwtToken(User user)
        {
            var jwtKey = _configuration["Jwt:Key"];
            var jwtIssuer = _configuration["Jwt:Issuer"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Username)
        };

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtIssuer,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
