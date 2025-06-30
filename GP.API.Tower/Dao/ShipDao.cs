namespace GP.API.Tower.Dao
{
    public class ShipDao
    {
        public string MMSI { get; set; } = null!;
        public string ShipName { get; set; } = null!;
        public decimal Draught { get; set; }
        public decimal Length { get; set; }
        public string Flag { get; set; } = null!;
        public DateTimeOffset? BuildingDate { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset? ModificationDate { get; set; }
    }
}
