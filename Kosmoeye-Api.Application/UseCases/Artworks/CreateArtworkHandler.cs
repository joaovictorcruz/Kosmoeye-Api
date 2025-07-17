using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Artwork;
using Kosmoeye_Api.Application.DTOS.Artwork.Create;
using Kosmoeye_Api.Domain.Entities;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Artworks
{
    public class CreateArtworkHandler
    {
        private readonly IArtworkRepository _artworkRepository;
        public CreateArtworkHandler(IArtworkRepository artworkRepository)
        {
            _artworkRepository = artworkRepository;
        }

        public async Task<ArtworkResponse> Handle(CreateArtworkCommand command)
        {
            var artwork = new Artwork(
                title: command.Title,
                fileUrl: command.FileUrl,
                authorId: command.AuthorId,
                isFreeToUse: command.IsFreeToUse,
                isPaid: command.IsPaid,
                price: command.Price,
                description: command.Description
                );

            await _artworkRepository.AddAsync(artwork);

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
