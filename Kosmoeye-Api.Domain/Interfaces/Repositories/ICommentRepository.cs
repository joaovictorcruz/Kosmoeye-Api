using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmoeye_Api.Domain.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        Task AddAsync(Comment comment);
        Task<List<Comment>> GetByArtworkIdAsync(Guid artworkId);
        Task<Comment?> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
