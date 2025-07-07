using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Artwork.Create;
using Kosmoeye_Api.Application.DTOS.Artwork.Search;

namespace Kosmoeye_Api.Application.Services.Interfaces
{
    public interface IArtworkService
    {
        Task<ArtworkResponse> CreateArtworkAsync(CreateArtworkCommand command);
        Task<List<ArtworkResponse>> GetAllArtworksAsync();
        Task<ArtworkResponse?> GetArtworkByIdAsync(Guid id);
        Task<List<ArtworkResponse>> SearchArtworksAsync(SearchArtworksQuery query);
    }
}
