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
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetCommentByArtworkIdAsync(Guid artworkId)
        {
            return await _context.Comments
                .Where(c => c.ArtworkId == artworkId).ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(Guid id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var comment = await GetByIdAsync(id);
            if (comment == null)
                throw new KeyNotFoundException("Comentário não encontrado para exclusão.");

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}

