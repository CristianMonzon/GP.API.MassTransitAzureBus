using GP.LIB.Messages.Dto;
using GP.MSG.MassTransitAzureBus.Ship;

namespace GP.API.Tower.Services
{
    public interface IShipPositionUpdatedConsumer
    {
        Task ConsumerAsync(ShipPositionUpdatedDao shipPositionUpdatedDao);
    }
}
