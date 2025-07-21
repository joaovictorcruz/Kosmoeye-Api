using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Artworks
{
    public class DeleteArtworkHandler
    {
        private readonly IArtworkRepository _artworkRepository;
        public DeleteArtworkHandler(IArtworkRepository artworkRepository)
        {
            _artworkRepository = artworkRepository;
        }

        public async Task Handle(Guid id, Guid userId)
        {
            var artwork = await _artworkRepository.GetByIdAsync(id);

            if (artwork == null)
                throw new KeyNotFoundException("Artwork não encontrada.");

            if (artwork.AuthorId != userId)
                throw new UnauthorizedAccessException("Você não tem permissão para deletar esta artwork.");

            await _artworkRepository.DeleteAsync(id);
        }
    }
}

