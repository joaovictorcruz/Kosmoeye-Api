using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.FavoriteArtworkResponse;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Favorites
{
    public class GetFavoritesByUserHandler
    {
        private readonly IFavoriteRepository _repository;

        public GetFavoritesByUserHandler(IFavoriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FavoriteArtworkResponse>> Handle(Guid userId)
        {
            var result = await _repository.GetByUserIdAsync(userId);

            return result.Select(f => new FavoriteArtworkResponse
            {
                Id = f.Id,
                UserId = f.UserId,
                ArtworkId = f.ArtworkId,
                CreatedAt = f.CreatedAt
            }).ToList();
        }
    }
}
