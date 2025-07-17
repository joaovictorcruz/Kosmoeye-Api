using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Artwork;
using Kosmoeye_Api.Application.DTOS.Artwork.Create;
using Kosmoeye_Api.Application.DTOS.Artwork.Search;
using Kosmoeye_Api.Application.DTOS.Artwork.Update;
using Kosmoeye_Api.Application.Services.Interfaces;
using Kosmoeye_Api.Application.UseCases.Artworks;

namespace Kosmoeye_Api.Application.Services
{
    public class ArtworkService : IArtworkService
    {
        private readonly CreateArtworkHandler _createHandler;
        private readonly GetAllArtworksHandler _getAllHandler;
        private readonly GetArtworkByIdHandler _getByIdHandler;
        private readonly SearchArtworksHandler _searchArtworksHandler;
        private readonly UpdateArtworkHandler _updateHandler;

        public ArtworkService(CreateArtworkHandler createHandler, GetAllArtworksHandler getAllHandler, 
            GetArtworkByIdHandler getByIdHandler, SearchArtworksHandler searchArtworksHandler, UpdateArtworkHandler updateHandler)
        {
            _createHandler = createHandler;
            _getAllHandler = getAllHandler;
            _getByIdHandler = getByIdHandler;
            _searchArtworksHandler = searchArtworksHandler;
            _updateHandler = updateHandler;
        }

        public async Task<ArtworkResponse> CreateArtworkAsync(CreateArtworkCommand command)
        {
            return await _createHandler.Handle(command);
        }
        public async Task<List<ArtworkResponse>> GetAllArtworksAsync()
        {
            return await _getAllHandler.Handle();
        }
        public async Task<ArtworkResponse?> GetArtworkByIdAsync(Guid id)
        {
            return await _getByIdHandler.Handle(id);
        }
        public async Task<List<ArtworkResponse>> SearchArtworksAsync(SearchArtworksQuery query)
        {
            return await _searchArtworksHandler.Handle(query);
        }
        public async Task<ArtworkResponse> UpdateArtworkAsync(UpdateArtworkCommand command)
         => await _updateHandler.Handle(command);
    }
}
