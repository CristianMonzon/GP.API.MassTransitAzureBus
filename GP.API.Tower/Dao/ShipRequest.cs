namespace GP.API.Tower.Dao
{
    public class ShipRequest
    {
        public string MMSI { get; set; } = null!;
        public string ShipName { get; set; } = null!;
        public decimal Draught { get; set; }
        public decimal Length { get; set; }        
        public string Flag { get; set; } = null!;                
    }
}
