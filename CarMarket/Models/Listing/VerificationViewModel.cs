using System.ComponentModel.DataAnnotations;

namespace CarMarket.Models.Listing
{
    public class VerificationViewModel
    {
        public int Id { get; set; }

        public string Vin { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int Generation { get; set; }

        public string Type { get; set; }

        [Display(Name = "Drive type")]
        public string DriveType { get; set; }

        [Display(Name = "Fuel type")]
        public string FuelType { get; set; }

        [Display(Name = "Engine volume")]
        public double EngineVolume { get; set; }

        [Display(Name = "Gear type")]
        public string GearType { get; set; }

        public string Color { get; set; }

        [Display(Name = "Is registrated?")]
        public bool IsRegistrated { get; set; }

        [Display(Name = "Is crashed?")]
        public bool IsCrashed { get; set; }

        [Display(Name = "Is pledged?")]
        public bool IsPledged { get; set; }
    }
}
