using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Follow;
using Kosmoeye_Api.Application.Services.Interfaces;
using Kosmoeye_Api.Application.UseCases.Follow;

namespace Kosmoeye_Api.Application.Services
{
    public class FollowService : IFollowService
    {
        private readonly FollowUserHandler _followHandler;
        private readonly UnfollowUserHandler _unfollowHandler;

        public FollowService(FollowUserHandler followHandler, UnfollowUserHandler unfollowHandler)
        {
            _followHandler = followHandler;
            _unfollowHandler = unfollowHandler;
        }

        public async Task<FollowResponse> FollowAsync(FollowUserCommand command)
            => await _followHandler.Handle(command);

        public async Task UnfollowAsync(UnfollowUserCommand command)
            => await _unfollowHandler.Handle(command);
    }
}
