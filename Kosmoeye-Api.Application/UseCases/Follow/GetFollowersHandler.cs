using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Follow;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Follow
{
    public class GetFollowersHandler
    {
        private readonly IFollowRepository _repository;

        public GetFollowersHandler(IFollowRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FollowResponse>> Handle(Guid userId)
        {
            var followers = await _repository.GetFollowersAsync(userId);

            return followers.Select(f => new FollowResponse
            {
                Id = f.Id,
                FollowerId = f.FollowerId,
                FollowedId = f.FollowedId,
                CreatedAt = f.CreatedAt
            }).ToList();
        }
    }
}
