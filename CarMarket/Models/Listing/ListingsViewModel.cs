using System.ComponentModel.DataAnnotations;

namespace CarMarket.Models.Listing
{
    public class ListingsViewModel
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        [DisplayFormat(NullDisplayText = "No information")]
        public int? Year { get; set; }

        [Display(Name = "Mileage, km")]
        public int Mileage { get; set; }

        [Display(Name = "Price, $")]
        public int Price { get; set; }

        public bool IsFavorite { get; set; }

    }
}
