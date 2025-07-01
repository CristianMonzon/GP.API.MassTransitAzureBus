using Microsoft.EntityFrameworkCore;

namespace GP.API.Model
{

    public class AppDbContext : DbContext
    {
        public DbSet<Ship> Ships { get; set; }

        public DbSet<ShipPosition> ShipPositions { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<ShipPosition>()
                .HasOne(s => s.Ship)
                .WithMany(sp => sp.ShipPositions)
                .HasForeignKey(fk => fk.MMSI);
        }
    }
}
