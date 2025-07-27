using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Auth
{
    public class RevokeRefreshTokenHandler
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public RevokeRefreshTokenHandler(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task Handle(string token, string ipAddress)
        {
            var refreshToken = await _refreshTokenRepository.GetByTokenAsync(token);
            if (refreshToken == null || !refreshToken.IsActive)
                throw new InvalidOperationException("Token inválido ou já revogado.");

            await _refreshTokenRepository.RevokeAsync(refreshToken, ipAddress);
        }
    }
}
