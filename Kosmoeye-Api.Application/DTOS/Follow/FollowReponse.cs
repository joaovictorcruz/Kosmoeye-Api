using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmoeye_Api.Application.DTOS.Follow
{
    public class FollowResponse
    {
        public Guid Id { get; set; }
        public Guid FollowerId { get; set; }
        public Guid FollowedId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
