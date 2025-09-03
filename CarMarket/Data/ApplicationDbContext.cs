using CarMarket.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarMarket.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Listing> Listings { get; set; }

        public DbSet<FavoriteListing> FavoriteListings { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Listing>()
               .HasOne(l => l.ApplicationUser)
               .WithMany(u => u.Listings)
               .HasForeignKey(l => l.ApplicationUserId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FavoriteListing>()
           .HasKey(f => new { f.ApplicationUserId, f.ListingId });

            modelBuilder.Entity<FavoriteListing>()
                .HasOne(f => f.ApplicationUser)
                .WithMany(u => u.FavoriteListings)
                .HasForeignKey(f => f.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FavoriteListing>()
                .HasOne(f => f.Listing)
                .WithMany(l => l.FavoriteListings)
                .HasForeignKey(f => f.ListingId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
