using GP.API.Model;
using Microsoft.EntityFrameworkCore;

namespace GP.API.Tower.Model
{

    public class TowerDbContext : AppDbContext
    {
        public TowerDbContext(DbContextOptions<TowerDbContext> options) : base(options) { }
    }

}
