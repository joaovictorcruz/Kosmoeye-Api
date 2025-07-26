using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Domain.Entities;

namespace Kosmoeye_Api.Domain.Interfaces.Repositories
{
    public interface IFollowRepository
    {
        Task AddAsync(Follow follow);
        Task RemoveAsync(Guid followerId, Guid followedId);
        Task<Follow?> GetByFollowerAndFollowedAsync(Guid followerId, Guid followedId);
        Task<List<Follow>> GetFollowersAsync(Guid userId);
        Task<List<Follow>> GetFollowingAsync(Guid userId);
        Task<int> CountFollowersAsync(Guid userId);
        Task<int> CountFollowingAsync(Guid userId);
    }
}
