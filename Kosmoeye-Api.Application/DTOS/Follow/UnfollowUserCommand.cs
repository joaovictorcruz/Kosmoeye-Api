using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmoeye_Api.Application.DTOS.Follow
{
    public class UnfollowUserCommand
    {
        public Guid FollowerId { get; set; }
        public Guid FollowedId { get; set; }
    }
}
