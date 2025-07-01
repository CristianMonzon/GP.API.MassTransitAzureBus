using GP.API.Ship.Dao;
using GP.LIB.Messages.Implementation;

namespace GP.API.Ship.Services
{
    public interface IShipService
    {
        Task<IEnumerable<ShipDao>> GetAllAsync();
        Task<Result<ShipDao>> CreateOrUpdateShip(ShipDao shipDao);        
    }
}
