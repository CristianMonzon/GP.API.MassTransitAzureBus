using GP.API.Tower.Dao;
using GP.API.Tower.Model;
using Microsoft.EntityFrameworkCore;

namespace GP.API.Tower.Repository.Implementation
{
    public class ShipPositionRepository(TowerDbContext appDbContext) : IShipPositionRepository
    {
        /// <summary>
        /// Creates the ship position.
        /// </summary>
        /// <param name="shipPositionUpdatedDao">The ship position updated DAO.</param>
        /// <returns></returns>
        public async Task<ShipPositionUpdatedDao> CreateShipPosition(ShipPositionUpdatedDao shipPositionUpdatedDao)
        {
            var shipPosition = shipPositionUpdatedDao.ToShipPosition();
            appDbContext.Add(shipPosition);
            await appDbContext.SaveChangesAsync();
            return shipPositionUpdatedDao;
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ShipPositionUpdatedDao>> GetAllAsync()
        {
            return await appDbContext.ShipPositions.Select(c => c.ToDao()).ToListAsync();
        }
    }
}
