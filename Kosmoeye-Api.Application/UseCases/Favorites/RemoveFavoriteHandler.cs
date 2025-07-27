using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.FavoriteArtwork;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Favorites
{
    public class RemoveFavoriteHandler
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public RemoveFavoriteHandler(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task Handle(RemoveFavoriteCommand command)
        {
            await _favoriteRepository.RemoveAsync(command.UserId, command.ArtworkId);
        }
    }
}
