using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Domain.Entities;

namespace Kosmoeye_Api.Domain.Interfaces.Repositories
{
    public interface ILikeRepository
    {
        Task AddAsync(Like like);
        Task RemoveAsync(Guid userId, Guid artworkId);
        Task<Like?> GetByUserAndArtworkAsync(Guid userId, Guid artworkId);
        Task<int> CountByArtworkAsync(Guid artworkId);
        Task<List<Like>> GetLikesByUserAsync(Guid userId);
    }
}
