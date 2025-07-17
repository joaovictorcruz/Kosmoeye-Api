using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Artwork;
using Kosmoeye_Api.Application.DTOS.Artwork.Search;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Artworks
{
    public class SearchArtworksHandler
    {
        private readonly IArtworkRepository _artworkRepository;

        public SearchArtworksHandler(IArtworkRepository artworkRepository)
        {
            _artworkRepository = artworkRepository;
        }

        public async Task<List<ArtworkResponse>> Handle(SearchArtworksQuery query)
        {
            var artworks = await _artworkRepository.SearchAsync(query.AuthorId, query.Search, query.IsPaid);

            return artworks.Select(a => new ArtworkResponse
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                FileUrl = a.FileUrl,
                IsFreeToUse = a.IsFreeToUse,
                IsPaid = a.IsPaid,
                IsDownloadable = a.IsDownloadable,
                Price = a.Price,
                CreatedAt = a.CreatedAt
            }).ToList();
        }
    }
}
