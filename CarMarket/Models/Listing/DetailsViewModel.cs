using System.ComponentModel.DataAnnotations;

namespace CarMarket.Models.Listing
{
    public class DetailsViewModel
    {
        public int Id { get; set; }

        public string Vin { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        [DisplayFormat(NullDisplayText = "No information")]
        public int? Year { get; set; }

        [DisplayFormat(NullDisplayText = "No information")]
        public int? Generation { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "No information")]
        public string? Type { get; set; }

        [Display(Name = "Drive type")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "No information")]
        public string? DriveType { get; set; }

        [Display(Name = "Fuel type")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "No information")]
        public string? FuelType { get; set; }

        [Display(Name = "Engine volume")]
        [DisplayFormat(NullDisplayText = "No information")]
        public double? EngineVolume { get; set; }

        [Display(Name = "Gear type")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "No information")]
        public string? GearType { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "No information")]
        public string? Color { get; set; }

        [Display(Name = "Is registrated?")]
        [DisplayFormat(NullDisplayText = "No information")]
        public bool? IsRegistrated { get; set; }

        [Display(Name = "Is crashed?")]
        [DisplayFormat(NullDisplayText = "No information")]
        public bool? IsCrashed { get; set; }

        [Display(Name = "Is pledged?")]
        [DisplayFormat(NullDisplayText = "No information")]
        public bool? IsPledged { get; set; }

        [Display(Name = "Mile age, km")]
        public int MileAge { get; set; }

        [Display(Name = "Price, $")]
        public int Price { get; set; }

        [Display(Name = "Owner Name")]
        public string UserName { get; set; }

        [Display(Name = "Contact Email")]
        public string Email { get; set; }

        [Display(Name = "Contact Phone")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "No information")]
        public string? PhoneNumber { get; set; }

        public bool IsFavorite { get; set; }
    }
}
