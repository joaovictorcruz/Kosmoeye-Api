using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmoeye_Api.Domain.Entities
{
    public class Follow
    {
        public Guid Id { get; private set; }
        public Guid FollowerId { get; private set; }
        public Guid FollowedId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Follow() { }

        public Follow(Guid followerId, Guid followedId)
        {
            Id = Guid.NewGuid();
            FollowerId = followerId;
            FollowedId = followedId;
            CreatedAt = DateTime.UtcNow;

            if (followerId == followedId)
                throw new Exception("Você não pode seguir a si mesmo.");
        }
    }
}
