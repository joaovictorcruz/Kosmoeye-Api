using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.FavoriteArtwork;
using Kosmoeye_Api.Application.DTOS.FavoriteArtworkResponse;
using Kosmoeye_Api.Application.Services.Interfaces;
using Kosmoeye_Api.Application.UseCases.Favorites;

namespace Kosmoeye_Api.Application.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly AddFavoriteHandler _addHandler;
        private readonly RemoveFavoriteHandler _removeHandler;

        public FavoriteService(AddFavoriteHandler addHandler, RemoveFavoriteHandler removeHandler)
        {
            _addHandler = addHandler;
            _removeHandler = removeHandler;
        }

        public async Task<FavoriteArtworkResponse> AddFavoriteAsync(AddFavoriteCommand command)
            => await _addHandler.Handle(command);

        public async Task RemoveFavoriteAsync(RemoveFavoriteCommand command)
            => await _removeHandler.Handle(command);
    }
}
