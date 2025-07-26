using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Domain.Entities;
using Kosmoeye_Api.Domain.Interfaces.Repositories;
using Kosmoeye_Api.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Kosmoeye_Api.Infrastructure.Persistence.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private readonly AppDbContext _context;

        public FollowRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Follow follow)
        {
            await _context.Follows.AddAsync(follow);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid followerId, Guid followedId)
        {
            var follow = await GetByFollowerAndFollowedAsync(followerId, followedId);
            if (follow != null)
            {
                _context.Follows.Remove(follow);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Follow?> GetByFollowerAndFollowedAsync(Guid followerId, Guid followedId)
        {
            return await _context.Follows
                .FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowedId == followedId);
        }

        public async Task<List<Follow>> GetFollowersAsync(Guid userId)
        {
            return await _context.Follows
                .Where(f => f.FollowedId == userId)
                .ToListAsync();
        }

        public async Task<List<Follow>> GetFollowingAsync(Guid userId)
        {
            return await _context.Follows
                .Where(f => f.FollowerId == userId)
                .ToListAsync();
        }

        public async Task<int> CountFollowersAsync(Guid userId)
        {
            return await _context.Follows.CountAsync(f => f.FollowedId == userId);
        }

        public async Task<int> CountFollowingAsync(Guid userId)
        {
            return await _context.Follows.CountAsync(f => f.FollowerId == userId);
        }
    }
}
