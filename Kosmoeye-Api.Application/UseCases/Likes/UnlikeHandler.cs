using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Like;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Likes
{
    public class UnlikeHandler
    {
        private readonly ILikeRepository _likeRepository;
        public UnlikeHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task Handle(UnlikeCommand command)
        {
            await _likeRepository.RemoveAsync(command.UserId, command.ArtworkId);
        }
    }
}
