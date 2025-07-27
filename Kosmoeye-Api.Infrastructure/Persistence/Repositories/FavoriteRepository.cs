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
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppDbContext _context;

        public FavoriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FavoriteArtwork favorite)
        {
            await _context.FavoriteArtworks.AddAsync(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid userId, Guid artworkId)
        {
            var fav = await GetByUserAndArtworkAsync(userId, artworkId);
            if (fav != null)
            {
                _context.FavoriteArtworks.Remove(fav);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<FavoriteArtwork?> GetByUserAndArtworkAsync(Guid userId, Guid artworkId)
        {
            return await _context.FavoriteArtworks
                .FirstOrDefaultAsync(f => f.UserId == userId && f.ArtworkId == artworkId);
        }
        public async Task<int> CountByArtworkAsync(Guid artworkId)
        {
            return await _context.FavoriteArtworks.CountAsync(f => f.ArtworkId == artworkId);
        }

        public async Task<List<FavoriteArtwork>> GetByUserIdAsync(Guid userId)
        {
            return await _context.FavoriteArtworks
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }
    }
}
