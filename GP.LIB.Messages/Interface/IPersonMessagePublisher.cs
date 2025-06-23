using GP.MSG.MassTransitAzureBus;

namespace GP.LIB.Messages.Interface
{
    public interface IPersonMessagePublisher
    {
        Task PublishAsync(PersonMessage message);
    }
}
