namespace GP.API.Tower.Model
{
    public class ShipPosition
    {
        public string MMSI { get; set; } = null!;
        public double Speed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Heading { get; set; }
        public DateTimeOffset EventDate { get; set; }
        public DateTimeOffset CreationDate { get; set; }
    }
}
