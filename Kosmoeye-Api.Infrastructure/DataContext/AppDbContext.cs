using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosmoeye_Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kosmoeye_Api.Infrastructure.DataContext
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Artwork> Artworks => Set<Artwork>();
        public DbSet<FavoriteArtwork> FavoriteArtworks => Set<FavoriteArtwork>();
        public DbSet<Like> Likes => Set<Like>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Follow> Follows => Set<Follow>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Username).HasMaxLength(50).IsRequired();
            });
        }
    }
}
