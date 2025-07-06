using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmoeye_Api.Application.DTOS.Artwork.Create
{
    public class CreateArtworkCommand
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string FileUrl { get; set; } = null!;
        public Guid AuthorId { get; set; }
        public bool IsFreeToUse { get; set; }
        public bool IsPaid { get; set; }
        public decimal? Price { get; set; }
    }
}
