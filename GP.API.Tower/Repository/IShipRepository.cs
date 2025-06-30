using GP.API.Tower.Dao;
using GP.API.Tower.Model;

namespace GP.API.Tower.Repository
{
    public interface IShipRepository
    {
        Task<IEnumerable<ShipDao>> GetAllAsync();
        Task<ShipDao> CreateOrUpdateShip(ShipDao shipDao);
    }

}
