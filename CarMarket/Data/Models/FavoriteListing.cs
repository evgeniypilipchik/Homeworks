using System.ComponentModel.DataAnnotations;

namespace CarMarket.Data.Models
{
    public class FavoriteListing
    {
        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public int ListingId { get; set; }

        [Required]
        public Listing Listing { get; set; }
    }
}
