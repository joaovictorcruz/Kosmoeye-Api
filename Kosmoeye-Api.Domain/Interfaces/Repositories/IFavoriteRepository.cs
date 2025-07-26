using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Domain.Entities;

namespace Kosmoeye_Api.Domain.Interfaces.Repositories
{
    public interface IFavoriteRepository
    {
        Task AddAsync(FavoriteArtwork favorite);
        Task RemoveAsync(Guid userId, Guid artworkId);
        Task<FavoriteArtwork?> GetByUserAndArtworkAsync(Guid userId, Guid artworkId);
        Task<int> CountByArtworkAsync(Guid artworkId);
        Task<List<FavoriteArtwork>> GetByUserIdAsync(Guid userId);
    }
}
