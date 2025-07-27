using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmoeye_Api.Application.DTOS.Comment
{
    public class CommentCommand
    {
        public Guid UserId { get; set; }
        public Guid ArtworkId { get; set; }
        public string Content { get; set; } = null!;
    }

}
