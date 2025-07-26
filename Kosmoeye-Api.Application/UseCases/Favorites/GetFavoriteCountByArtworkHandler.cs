using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Favorites
{
    public class GetFavoriteCountByArtworkHandler
    {
        private readonly IFavoriteRepository _repository;

        public GetFavoriteCountByArtworkHandler(IFavoriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(Guid artworkId)
        {
            return await _repository.CountByArtworkAsync(artworkId);
        }
    }
}
