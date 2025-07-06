using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Artwork.Create;

namespace Kosmoeye_Api.Application.Services.Interfaces
{
    public interface IArtworkService
    {
        Task<ArtworkResponse> CreateArtworkAsync(CreateArtworkCommand command);
    }
}
