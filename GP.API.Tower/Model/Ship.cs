using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GP.API.Tower.Model
{
    [Table("Ship"), Comment(nameof(Ship))]
    public class Ship
    {
        [Key, Column("MMSI"), Comment(nameof(MMSI))]
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
