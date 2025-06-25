namespace GP.MSG.MassTransitAzureBus.Ship
{
    public record ShipPositionUpdated
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