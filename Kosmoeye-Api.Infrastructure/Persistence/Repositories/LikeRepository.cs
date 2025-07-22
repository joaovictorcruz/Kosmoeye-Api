using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Domain.Entities;
using Kosmoeye_Api.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Kosmoeye_Api.Infrastructure.Persistence.Repositories
{
    public class LikeRepository
    {
        private readonly AppDbContext _context;

        public LikeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Like like)
        {
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid userId, Guid artworkId)
        {
            var like = await GetByUserAndArtworkAsync(userId, artworkId);
            if (like != null)
            {
                _context.Likes.Remove(like);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Like?> GetByUserAndArtworkAsync(Guid userId, Guid artworkId)
        {
            return await _context.Likes
                .FirstOrDefaultAsync(l => l.UserId == userId && l.ArtworkId == artworkId);
        }

        public async Task<int> CountByArtworkAsync(Guid artworkId)
        {
            return await _context.Likes.CountAsync(l => l.ArtworkId == artworkId);
        }
    }
}
