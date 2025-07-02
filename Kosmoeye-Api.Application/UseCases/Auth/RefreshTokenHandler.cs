using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Auth;
using Kosmoeye_Api.Application.Services;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Auth
{
    public class RefreshTokenHandler
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly TokenGenerator _tokenGenerator;

        public RefreshTokenHandler(
            IRefreshTokenRepository refreshTokenRepository,
            TokenGenerator tokenGenerator)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<LoginUserResponse> Handle(string oldToken, string ipAddress)
        {
            var existingToken = await _refreshTokenRepository.GetByTokenAsync(oldToken);

            if (existingToken == null || !existingToken.IsActive)
                throw new UnauthorizedAccessException("Refresh token inválido ou expirado.");

            var user = existingToken.User;

            var newRefreshToken = _tokenGenerator.GenerateRefreshToken(ipAddress);
            newRefreshToken.UserId = user.Id;

            await _refreshTokenRepository.RevokeAsync(existingToken, ipAddress, newRefreshToken.Token);
            await _refreshTokenRepository.AddAsync(newRefreshToken);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username),
            };

            var newAccessToken = _tokenGenerator.GenerateJwtToken(user);

            return new LoginUserResponse
            {
                JwtToken = newAccessToken,
                RefreshToken = newRefreshToken.Token,
                ExpiresAt = newRefreshToken.ExpiresAt
            };
        }
    }
}
