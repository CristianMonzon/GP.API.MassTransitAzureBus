using GP.API.Ship.Dao;
using GP.API.Ship.Repository;
using GP.LIB.Messages.Implementation;

namespace GP.API.Ship.Services.Implementation
{
    public class ShipService(IShipRepository shipRepository) : IShipService
    {
        /// <summary>
        /// Creates the or update ship.
        /// </summary>
        /// <param name="shipDao">The ship DAO.</param>
        /// <returns></returns>
        public async Task<Result<ShipDao>> CreateOrUpdateShip(ShipDao shipDao)
        {
            var result = new Result<ShipDao>();

            try
            {
                var shipDaoReturn = await shipRepository.CreateOrUpdateShip(shipDao);
                result.SetOK(shipDaoReturn);

            }
            catch (Exception ex)
            {

                result.SetError(ex);
            }
            return result;
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ShipDao>> GetAllAsync()
        {
            return await shipRepository.GetAllAsync();
        }
    }
}
