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

        public LikeService(LikeHandler likeHandler, UnlikeHandler unlikeHandler)
        {
            _likeHandler = likeHandler;
            _unlikeHandler = unlikeHandler;
        }

        public async Task<LikeResponse> LikeAsync(LikeCommand command)
            => await _likeHandler.Handle(command);

        public async Task UnlikeAsync(UnlikeCommand command)
            => await _unlikeHandler.Handle(command);
    }
}

