using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmoeye_Api.Domain.Entities
{
    public class Like
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ArtworkId { get; private set; }
        public DateTime LikedAt { get; private set; }

        private Like() { }

        public Like(Guid userId, Guid artworkId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            ArtworkId = artworkId;
            LikedAt = DateTime.UtcNow;
        }
    }
}
