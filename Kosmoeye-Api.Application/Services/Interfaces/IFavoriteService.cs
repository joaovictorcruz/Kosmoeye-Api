using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.FavoriteArtwork;
using Kosmoeye_Api.Application.DTOS.FavoriteArtworkResponse;

namespace Kosmoeye_Api.Application.Services.Interfaces
{
    public interface IFavoriteService
    {
        Task<FavoriteArtworkResponse> AddFavoriteAsync(AddFavoriteCommand command);
        Task RemoveFavoriteAsync(RemoveFavoriteCommand command);
    }
}
