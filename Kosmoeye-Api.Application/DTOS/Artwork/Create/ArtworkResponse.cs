using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmoeye_Api.Application.DTOS.Artwork.Create
{
    public class ArtworkResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string FileUrl { get; set; } = null!;
        public bool IsFreeToUse { get; set; }
        public bool IsDownloadable { get; set; }
        public bool IsPaid { get; set; }
        public decimal? Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
