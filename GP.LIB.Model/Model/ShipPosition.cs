using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GP.API.Model
{
    [Table("ShipPosition"), Comment(nameof(Ship))]
    public class ShipPosition
    {
        [Key]
        public int Id { get; set; }
        public string MMSI { get; set; } = null!;
        public DateTimeOffset EventDate { get; set; }
        public double Speed { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Heading { get; set; }
        public DateTimeOffset CreationDate { get; set; }        
        [ForeignKey(nameof(MMSI))]
        public Ship Ship { get; set; } = null!;
    }
}
