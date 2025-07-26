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
        private readonly GetFavoriteCountByArtworkHandler _countHandler;
        private readonly GetFavoritesByUserHandler _byUserHandler;


        public FavoriteService(AddFavoriteHandler addHandler, RemoveFavoriteHandler removeHandler, 
            GetFavoriteCountByArtworkHandler countHandler, GetFavoritesByUserHandler byUserHandler)
        {
            _addHandler = addHandler;
            _removeHandler = removeHandler;
            _countHandler = countHandler;
            _byUserHandler = byUserHandler;
        }

        public async Task<FavoriteArtworkResponse> AddFavoriteAsync(AddFavoriteCommand command)
            => await _addHandler.Handle(command);

        public async Task RemoveFavoriteAsync(RemoveFavoriteCommand command)
            => await _removeHandler.Handle(command);
        public async Task<int> GetFavoriteCountByArtworkAsync(Guid artworkId)
            => await _countHandler.Handle(artworkId);

        public async Task<List<FavoriteArtworkResponse>> GetFavoritesByUserAsync(Guid userId)
            => await _byUserHandler.Handle(userId);
    }
}
