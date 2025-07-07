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
    public class ArtworkRepository : IArtworkRepository
    {
        private readonly AppDbContext _context;

        public ArtworkRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Artwork artwork)
        {
            await _context.Artworks.AddAsync(artwork); 
            await _context.SaveChangesAsync();
        }
        public async Task<List<Artwork>> GetAllAsync()
        {
            return await _context.Artworks.ToListAsync();
        }
        public async Task<Artwork?> GetByIdAsync(Guid id)
        {
            return await _context.Artworks.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<List<Artwork>> SearchAsync(Guid? authorId, string? search, bool? isPaid)
        {
            var query = _context.Artworks.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(a =>
                    a.Title.Contains(search) || 
                    (a.Description != null && a.Description.Contains(search)));

            if (authorId.HasValue)
                query = query.Where(a => a.AuthorId == authorId);

            if (isPaid.HasValue)
                query = query.Where(a => a.IsPaid == isPaid);

            return await query.ToListAsync();
        }
    }
}
