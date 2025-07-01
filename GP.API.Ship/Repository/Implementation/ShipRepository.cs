using GP.API.Ship.Dao;
using GP.API.Ship.Model;
using Microsoft.EntityFrameworkCore;

namespace GP.API.Ship.Repository.Implementation
{
    public class ShipRepository(ShipDbContext appDbContext) : IShipRepository
    {

        /// <summary>
        /// Creates the or update ship.
        /// </summary>
        /// <param name="shipDao">The ship DAO.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ShipDao>> GetAllAsync()
        {
            return await appDbContext.Ships.Select(c => c.ToDao()).ToListAsync();
        }
    }
}
