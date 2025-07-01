using GP.API.Tower.Dao;

namespace GP.API.Tower.Repository
{
    public interface IShipPositionRepository
    {
        Task<ShipPositionUpdatedDao> CreateShipPosition(ShipPositionUpdatedDao shipPositionUpdatedDao);
        Task<IEnumerable<ShipPositionUpdatedDao>> GetAllAsync(); 
    }

}
