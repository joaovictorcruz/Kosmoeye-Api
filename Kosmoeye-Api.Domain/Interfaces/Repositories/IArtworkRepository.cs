using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Domain.Entities;

namespace Kosmoeye_Api.Domain.Interfaces.Repositories
{
    public interface IArtworkRepository
    {
        Task AddAsync(Artwork artwork);
        Task<List<Artwork>> GetAllAsync();
        Task<Artwork?> GetByIdAsync(Guid id);

    }
}
