using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Follow;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Follow
{
    public class UnfollowUserHandler
    {
        private readonly IFollowRepository _repository;

        public UnfollowUserHandler(IFollowRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UnfollowUserCommand command)
        {
            await _repository.RemoveAsync(command.FollowerId, command.FollowedId);
        }
    }
}
