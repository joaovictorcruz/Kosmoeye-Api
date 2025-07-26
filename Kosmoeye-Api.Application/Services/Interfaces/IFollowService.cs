using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Application.DTOS.Follow;

namespace Kosmoeye_Api.Application.Services.Interfaces
{
    public interface IFollowService
    {
        Task<FollowResponse> FollowAsync(FollowUserCommand command);
        Task UnfollowAsync(UnfollowUserCommand command);
    }
}
