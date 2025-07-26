using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.FavoriteArtworkResponse;
using Kosmoeye_Api.Domain.Entities;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Favorites
{
    public class AddFavoriteHandler
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public AddFavoriteHandler(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<FavoriteArtworkResponse> Handle(AddFavoriteCommand command)
        {
            var existing = await _favoriteRepository.GetByUserAndArtworkAsync(command.UserId, command.ArtworkId);
            if (existing != null)
                throw new InvalidOperationException("Essa arte ja foi favorita pelo usuário.");

            var favorite = new FavoriteArtwork(command.UserId, command.ArtworkId);
            await _favoriteRepository.AddAsync(favorite);

            return new FavoriteArtworkResponse
            {
                Id = favorite.Id,
                UserId = favorite.UserId,
                ArtworkId = favorite.ArtworkId,
                CreatedAt = favorite.CreatedAt
            };
        }
    }
}
