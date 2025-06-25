namespace GP.LIB.Messages.Dto
{
    public class ShipPositionUpdatedDao
    {
        /// <summary>
        /// Maritime Mobile Service Identity
        /// </summary>
        public string MMSI { get; set; } = null!;
        public double Speed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Heading { get; set; }
        public DateTimeOffset EventDate { get; set; }
    }
}
