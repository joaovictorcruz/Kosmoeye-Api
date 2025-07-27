using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Follow;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Follow
{
    public class GetFollowInfoHandler
    {
        private readonly IFollowRepository _repository;

        public GetFollowInfoHandler(IFollowRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserFollowInfoResponse> Handle(Guid userId)
        {
            var followers = await _repository.CountFollowersAsync(userId);
            var following = await _repository.CountFollowingAsync(userId);

            return new UserFollowInfoResponse
            {
                Followers = followers,
                Following = following
            };
        }
    }
}
