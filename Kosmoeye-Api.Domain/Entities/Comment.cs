using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmoeye_Api.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ArtworkId { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Comment() { }

        public Comment(Guid userId, Guid artworkId, string content)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            ArtworkId = artworkId;
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
