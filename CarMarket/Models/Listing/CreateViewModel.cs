using System.ComponentModel.DataAnnotations;

namespace CarMarket.Models.Listing
{
    public class CreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the car VIN")]
        [RegularExpression(@"^\d{3}[A-Z]\d{3}$", ErrorMessage = "Please enter the car VIN in the form 000А000 using the Latin alphabet.")]
        public string Vin { get; set; }

        [Required(ErrorMessage = "Please enter the car brand")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Please enter the car model")]
        public string Model { get; set; }

        public int? Year { get; set; }

        public int? Generation { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? Type { get; set; }

        [Display(Name = "Drive type")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? DriveType { get; set; }

        [Display(Name = "Fuel type")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? FuelType { get; set; }

        [Display(Name = "Engine volume")]
        public double? EngineVolume { get; set; }

        [Display(Name = "Gear type")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? GearType { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? Color { get; set; }

        [Display(Name = "Is registrated?")]
        public bool? IsRegistrated { get; set; }

        [Display(Name = "Is crashed?")]
        public bool? IsCrashed { get; set; }

        [Display(Name = "Is pledged?")]
        public bool? IsPledged { get; set; }

        [Display(Name = "Mileage, km")]
        [Required(ErrorMessage = "Please enter the car mile age")]
        [Range(0, 1_000_000, ErrorMessage = "The car mile age must be from 0 to 1 000 000 km")]
        public int Mileage { get; set; }

        [Display(Name = "Price, $")]
        [Required(ErrorMessage = "Please enter the car price")]
        [Range(1, 1_000_000_000, ErrorMessage = "The car price must be from 0 to 1 000 000 000 $")]
        public int Price { get; set; }
    }
}
