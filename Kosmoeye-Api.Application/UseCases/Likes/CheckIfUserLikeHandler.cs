using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Likes
{
    public class CheckIfUserLikedHandler
    {
        private readonly ILikeRepository _likeRepository;

        public CheckIfUserLikedHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<bool> Handle(Guid userId, Guid artworkId)
        {
            var like = await _likeRepository.GetByUserAndArtworkAsync(userId, artworkId);
            return like != null;
        }
    }
}
