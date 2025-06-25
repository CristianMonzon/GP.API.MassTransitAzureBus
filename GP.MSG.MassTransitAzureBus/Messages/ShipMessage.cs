
namespace GP.MSG.MassTransitAzureBus
{
    public class ShipMessage
    {
        public string MMSI { get; set; } = null!;
        public string ShipName { get; set; } = null!;
        public decimal Draught { get; set; }
        public decimal Length { get; set; }
        public string Origin { get; set; } = null!;
        public string Flag { get; set; } = null!;
        public DateTime? BuildingDate { get; set; }
    }
}
