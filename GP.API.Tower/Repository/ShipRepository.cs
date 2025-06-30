using GP.API.Tower.Dao;
using GP.API.Tower.Model;
using Microsoft.EntityFrameworkCore;

namespace GP.API.Tower.Repository
{
    public class ShipRepository(AppDbContext appDbContext) : IShipRepository
    {

        public async Task<ShipDao> CreateOrUpdateShip(ShipDao shipDao)
        {
            var existingShip = await appDbContext.Ships.FirstOrDefaultAsync(s => s.MMSI == shipDao.MMSI);

            if (existingShip == null)
            {                
                var newShip = shipDao.ToShip();
                newShip.CreationDate = DateTime.UtcNow;                

                appDbContext.Ships.Add(newShip);
                await appDbContext.SaveChangesAsync();

                return newShip.ToDao();
            }
            else
            {             
                existingShip.ShipName = shipDao.ShipName;
                existingShip.Flag = shipDao.Flag;
                existingShip.Draught = shipDao.Draught;
                existingShip.Length = shipDao.Length;
                existingShip.BuildingDate = shipDao.BuildingDate;
                existingShip.ModificationDate = DateTime.UtcNow;

                await appDbContext.SaveChangesAsync();

                return existingShip.ToDao();
            }
        }

        public async Task<IEnumerable<ShipDao>> GetAllAsync()
        {
            return await appDbContext.Ships.Select(c => c.ToDao()).ToListAsync();
        }
    }
}
