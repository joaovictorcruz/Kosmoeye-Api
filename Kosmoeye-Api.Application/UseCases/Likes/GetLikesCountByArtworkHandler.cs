using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Likes
{
    public class GetLikesCountByArtworkHandler
    {
        private readonly ILikeRepository _likeRepository;

        public GetLikesCountByArtworkHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<int> Handle(Guid artworkId)
        {
            return await _likeRepository.CountByArtworkAsync(artworkId);
        }
    }
}
