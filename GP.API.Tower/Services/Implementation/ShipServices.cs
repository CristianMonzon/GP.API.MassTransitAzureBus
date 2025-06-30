using GP.API.Tower.Dao;
using GP.API.Tower.Repository;
using GP.LIB.Messages.Implementation;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GP.API.Tower.Services.Implementation
{
    public class ShipService(IShipRepository shipRepository) : IShipService
    {
        
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

        public async Task<IEnumerable<ShipDao>> GetAllAsync()
        {
            return await shipRepository.GetAllAsync();
        }
    }
}
