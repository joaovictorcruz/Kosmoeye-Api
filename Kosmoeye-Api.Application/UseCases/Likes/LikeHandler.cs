using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Like;
using Kosmoeye_Api.Domain.Entities;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Likes
{
    public class LikeHandler
    {
        private readonly ILikeRepository _likeRepository;

        public LikeHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<LikeResponse> Handle(LikeCommand command)
        {
            var existingLike = await _likeRepository.GetByUserAndArtworkAsync(command.UserId, command.ArtworkId);

            if (existingLike != null)
                throw new InvalidOperationException("Usuário já curtiu esta artwork.");

            var like = new Like(command.UserId, command.ArtworkId);

            await _likeRepository.AddAsync(like);

            return new LikeResponse
            {
                ArtworkId = like.ArtworkId,
                UserId = like.UserId,
                LikedAt = like.LikedAt
            };
        }
    }
}
