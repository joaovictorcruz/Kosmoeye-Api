using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Artwork.Create;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Artworks
{
    public class GetArtworkByIdHandler
    {
        private readonly IArtworkRepository _artworkRepository;

        public GetArtworkByIdHandler(IArtworkRepository artworkRepository)
        {
            _artworkRepository = artworkRepository;
        }

        public async Task<ArtworkResponse> Handle(Guid id)
        {
            var artwork = await _artworkRepository.GetByIdAsync(id);
            if (artwork == null) return null;
            return new ArtworkResponse
            {
                Id = artwork.Id,
                Title = artwork.Title,
                Description = artwork.Description,
                FileUrl = artwork.FileUrl,
                IsFreeToUse = artwork.IsFreeToUse,
                IsPaid = artwork.IsPaid,
                IsDownloadable = artwork.IsDownloadable,
                Price = artwork.Price,
                CreatedAt = artwork.CreatedAt
            };
        }
    }
}
