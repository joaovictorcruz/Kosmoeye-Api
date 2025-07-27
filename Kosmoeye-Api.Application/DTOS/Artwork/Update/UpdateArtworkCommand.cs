using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmoeye_Api.Application.DTOS.Artwork.Update
{
    public class UpdateArtworkCommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsFreeToUse { get; set; }
        public bool IsPaid { get; set; }
        public decimal? Price { get; set; }
        public Guid AuthorId { get; set; }
    }
}
