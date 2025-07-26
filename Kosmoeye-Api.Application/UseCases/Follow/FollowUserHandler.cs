using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Follow;
using Kosmoeye_Api.Domain.Entities;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Follow
{
    public class FollowUserHandler
    {
        private readonly IFollowRepository _repository;

        public FollowUserHandler(IFollowRepository repository)
        {
            _repository = repository;
        }

        public async Task<FollowResponse> Handle(FollowUserCommand command)
        {
            var exists = await _repository.GetByFollowerAndFollowedAsync(command.FollowerId, command.FollowedId);
            if (exists != null)
                throw new InvalidOperationException("Usuário já está sendo seguido.");

            var follow = new Domain.Entities.Follow(command.FollowerId, command.FollowedId);
            await _repository.AddAsync(follow);

            return new FollowResponse
            {
                Id = follow.Id,
                FollowerId = follow.FollowerId,
                FollowedId = follow.FollowedId,
                CreatedAt = follow.CreatedAt
            };
        }
    }
}
