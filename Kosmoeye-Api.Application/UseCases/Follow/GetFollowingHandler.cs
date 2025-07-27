using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Follow;
using Kosmoeye_Api.Domain.Interfaces.Repositories;

namespace Kosmoeye_Api.Application.UseCases.Follow
{
    public class GetFollowingHandler
    {
        private readonly IFollowRepository _repository;

        public GetFollowingHandler(IFollowRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FollowResponse>> Handle(Guid userId)
        {
            var following = await _repository.GetFollowingAsync(userId);

            return following.Select(f => new FollowResponse
            {
                Id = f.Id,
                FollowerId = f.FollowerId,
                FollowedId = f.FollowedId,
                CreatedAt = f.CreatedAt
            }).ToList();
        }
    }
}
