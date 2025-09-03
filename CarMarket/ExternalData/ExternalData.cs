namespace CarMarket.ExternalData
{
    public class ExternalData
    {
        public int Id { get; set; }

        public string Vin { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public int Generation { get; set; }

        public string Type { get; set; }

        public string DriveType { get; set; }

        public string FuelType { get; set; }

        public double EngineVolume { get; set; }

        public string GearType { get; set; }

        public string Color { get; set; }

        public bool IsRegistrated { get; set; }

        public bool IsCrashed { get; set; }

        public bool IsPledged { get; set; }
    }
}
