using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmoeye_Api.Domain.Entities
{
    public class Artwork
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public string FileUrl { get; private set; }
        public Guid AuthorId { get; private set; }

        public bool IsFreeToUse { get; private set; }
        public bool IsDownloadable { get; private set; }
        public bool IsPaid { get; private set; }
        public decimal? Price { get; private set; }

        public DateTime CreatedAt { get; private set; }

        private Artwork() { }

        public Artwork(
            string title,
            string fileUrl,
            Guid authorId,
            bool isFreeToUse,
            bool isPaid,
            decimal? price = null,
            string? description = null
        )
        {
            Id = Guid.NewGuid();
            Title = title;
            FileUrl = fileUrl;
            Description = description;
            AuthorId = authorId;
            CreatedAt = DateTime.UtcNow;

            IsFreeToUse = isFreeToUse;
            IsPaid = isPaid;
            IsDownloadable = isFreeToUse;

            if (isPaid && (price == null || price <= 0))
                throw new Exception("Preço inválido para conteúdo pago.");

            Price = isPaid ? price : null;
        }
        public void UpdateDetails(string title, string? description, bool isFreeToUse, bool isPaid, decimal? price)
        {
            Title = title;
            Description = description;
            IsFreeToUse = isFreeToUse;
            IsPaid = isPaid;
            IsDownloadable = isFreeToUse;

            if (isPaid)
            {
                if (price == null || price <= 0)
                    throw new Exception("Preço inválido para conteúdo pago.");

                Price = price;
            }
            else
            {
                Price = null;
            }
        }

    }
}
