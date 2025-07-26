using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Like;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Likes
{
    public class GetLikesByUserHandler
    {
        private readonly ILikeRepository _likeRepository;

        public GetLikesByUserHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<List<LikeResponse>> Handle(Guid userId)
        {
            var likes = await _likeRepository.GetLikesByUserAsync(userId);

            return likes.Select(l => new LikeResponse
            {
                ArtworkId = l.ArtworkId,
                UserId = l.UserId,
                LikedAt = l.LikedAt
            }).ToList();
        }
    }
}
