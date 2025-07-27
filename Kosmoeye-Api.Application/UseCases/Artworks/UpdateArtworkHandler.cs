using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Artwork;
using Kosmoeye_Api.Application.DTOS.Artwork.Update;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Artworks
{
    public class UpdateArtworkHandler
    {
        private readonly IArtworkRepository _artworkRepository;

        public UpdateArtworkHandler(IArtworkRepository artworkRepository)
        {
            _artworkRepository = artworkRepository;
        }

        public async Task<ArtworkResponse> Handle(UpdateArtworkCommand command)
        {
            var artwork = await _artworkRepository.GetByIdAsync(command.Id);

            if (artwork == null)
                throw new KeyNotFoundException("Artwork não encontrada.");

            if (artwork.AuthorId != command.AuthorId)
                throw new UnauthorizedAccessException("Você não tem permissão para atualizar esta artwork.");

            artwork.UpdateDetails(command.Title, command.Description, command.IsFreeToUse, command.IsPaid, command.Price);

            await _artworkRepository.UpdateAsync(artwork);

            return new ArtworkResponse
            {
                Id = artwork.Id,
                Title = artwork.Title,
                Description = artwork.Description,
                FileUrl = artwork.FileUrl,
                IsFreeToUse = artwork.IsFreeToUse,
                IsDownloadable = artwork.IsDownloadable,
                IsPaid = artwork.IsPaid,
                Price = artwork.Price,
                AuthorId = artwork.AuthorId
            };
        }
    }
}
