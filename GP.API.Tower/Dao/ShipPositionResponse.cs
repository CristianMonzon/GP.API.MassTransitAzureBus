namespace GP.API.Tower.Dao
{
    public class ShipPositionResponse
    {
        public int Id { get; set; }
        public string MMSI { get; set; } = null!;
        public DateTimeOffset EventDate { get; set; }
        public double Speed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Heading { get; set; }
        public DateTimeOffset CreationDate { get; set; }
    }
}
