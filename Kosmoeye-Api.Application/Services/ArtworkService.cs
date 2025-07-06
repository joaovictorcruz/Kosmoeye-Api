using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Artwork.Create;
using Kosmoeye_Api.Application.Services.Interfaces;
using Kosmoeye_Api.Application.UseCases.Artworks;

namespace Kosmoeye_Api.Application.Services
{
    public class ArtworkService : IArtworkService
    {
        private readonly CreateArtworkHandler _createHandler;
        public ArtworkService(CreateArtworkHandler createHandler)
        {
            _createHandler = createHandler; 
        }

        public async Task<ArtworkResponse> CreateArtworkAsync(CreateArtworkCommand command)
        {
            return await _createHandler.Handle(command);
        }
    }
}
