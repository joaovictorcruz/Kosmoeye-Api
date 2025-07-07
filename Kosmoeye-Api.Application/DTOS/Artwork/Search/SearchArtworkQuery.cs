using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmoeye_Api.Application.DTOS.Artwork.Search
{
    public class SearchArtworksQuery
    {
        public Guid? AuthorId { get; set; }
        public string? Search { get; set; }
        public bool? IsPaid { get; set; }
    }
}
