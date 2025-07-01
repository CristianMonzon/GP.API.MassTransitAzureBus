using GP.API.Tower.Dao;

namespace GP.API.Tower.Services
{
    public interface IShipPositionUpdatedConsumer
    {
        Task ConsumerAsync(ShipPositionUpdatedDao shipPositionUpdatedDao);
    }
}
