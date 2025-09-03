using Microsoft.AspNetCore.Identity;

namespace CarMarket.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Listing> Listings { get; set; } = new();

        public List<FavoriteListing> FavoriteListings { get; set; } = new();
    }
}
