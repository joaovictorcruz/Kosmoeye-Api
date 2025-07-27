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
        private readonly GetFollowersHandler _followersHandler;
        private readonly GetFollowingHandler _followingHandler;
        private readonly GetFollowInfoHandler _infoHandler;

        public FollowService(
            FollowUserHandler followHandler,
            UnfollowUserHandler unfollowHandler,
            GetFollowersHandler followersHandler,
            GetFollowingHandler followingHandler,
            GetFollowInfoHandler infoHandler)
        {
            _followHandler = followHandler;
            _unfollowHandler = unfollowHandler;
            _followersHandler = followersHandler;
            _followingHandler = followingHandler;
            _infoHandler = infoHandler;
        }

        public async Task<FollowResponse> FollowAsync(FollowUserCommand command)
            => await _followHandler.Handle(command);

        public async Task UnfollowAsync(UnfollowUserCommand command)
            => await _unfollowHandler.Handle(command);

        public async Task<List<FollowResponse>> GetFollowersAsync(Guid userId)
            => await _followersHandler.Handle(userId);

        public async Task<List<FollowResponse>> GetFollowingAsync(Guid userId)
            => await _followingHandler.Handle(userId);

        public async Task<UserFollowInfoResponse> GetFollowInfoAsync(Guid userId)
            => await _infoHandler.Handle(userId);

    }
}
