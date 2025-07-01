using GP.API.Ship.Dao;

namespace GP.API.Ship.Repository
{
    public interface IShipRepository
    {
        Task<IEnumerable<ShipDao>> GetAllAsync();
        Task<ShipDao> CreateOrUpdateShip(ShipDao shipDao);
    }
}
