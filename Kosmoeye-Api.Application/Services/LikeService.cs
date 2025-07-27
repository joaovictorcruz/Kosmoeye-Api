using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Like;
using Kosmoeye_Api.Application.Services.Interfaces;
using Kosmoeye_Api.Application.UseCases.Likes;

namespace Kosmoeye_Api.Application.Services
{
    public class LikeService : ILikeService
    {
        private readonly LikeHandler _likeHandler;
        private readonly UnlikeHandler _unlikeHandler;
        private readonly GetLikesCountByArtworkHandler _getLikesCountByArtworkHandler;
        private readonly GetLikesByUserHandler _getLikesByUserHandler;
        private readonly CheckIfUserLikedHandler _checkHandler;

        public LikeService(LikeHandler likeHandler, UnlikeHandler unlikeHandler, 
            GetLikesCountByArtworkHandler getLikesCountByArtworkHandler, GetLikesByUserHandler getLikesByUserHandler, CheckIfUserLikedHandler checkHandler)
        {
            _likeHandler = likeHandler;
            _unlikeHandler = unlikeHandler;
            _getLikesCountByArtworkHandler = getLikesCountByArtworkHandler;
            _getLikesByUserHandler = getLikesByUserHandler;
            _checkHandler = checkHandler;
        }

        public async Task<LikeResponse> LikeAsync(LikeCommand command)
            => await _likeHandler.Handle(command);

        public async Task UnlikeAsync(UnlikeCommand command)
            => await _unlikeHandler.Handle(command);

        public async Task<int> GetLikeCountByArtworkAsync(Guid artworkId)
            => await _getLikesCountByArtworkHandler.Handle(artworkId);

        public async Task<List<LikeResponse>> GetLikesByUserAsync(Guid userId)
            => await _getLikesByUserHandler.Handle(userId);
        public async Task<bool> HasUserLikedAsync(Guid userId, Guid artworkId)
            => await _checkHandler.Handle(userId, artworkId);
    }
}

