using GP.API.Tower.Dao;
using GP.API.Tower.Model;

namespace GP.API.Tower.Repository.Implementation
{
    public class ShipPositionRepository(TowerDbContext shipDbContext) : IShipPositionRepository
    {
        /// <summary>
        /// Creates the ship position.
        /// </summary>
        /// <param name="shipPositionUpdatedDao">The ship position updated DAO.</param>
        /// <returns></returns>
        public async Task<ShipPositionUpdatedDao> CreateShipPosition(ShipPositionUpdatedDao shipPositionUpdatedDao)
        {
            var shipPosition = shipPositionUpdatedDao.ToShipPosition();
            shipDbContext.Add(shipPosition);
            await shipDbContext.SaveChangesAsync();
            return shipPositionUpdatedDao;
        }
    }
}
