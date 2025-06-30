using GP.API.Tower.Dao;
using GP.LIB.Messages.Implementation;

namespace GP.API.Tower.Services
{
    public interface IShipService
    {
        Task<IEnumerable<ShipDao>> GetAllAsync();
        Task<Result<ShipDao>> CreateOrUpdateShip(ShipDao shipDao);        
    }
}
