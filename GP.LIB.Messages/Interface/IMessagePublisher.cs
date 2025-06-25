using GP.MSG.MassTransitAzureBus;
using GP.MSG.MassTransitAzureBus.Ship;

namespace GP.LIB.Messages.Interface
{
    public interface IMessagePublisher
    {
        Task PublishAsync(ShipMessage message);
        Task PublishAsync(ShipPositionUpdated message);
    }
}