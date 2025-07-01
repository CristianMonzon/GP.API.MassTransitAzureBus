using GP.API.Model;
using Microsoft.EntityFrameworkCore;

namespace GP.API.Ship.Model
{
    public class ShipDbContext : AppDbContext
    {
        public ShipDbContext(DbContextOptions<ShipDbContext> options) : base(options) { }
    }
}
