using GP.LIB.Messages.Dto;
using GP.MSG.MassTransitAzureBus.Ship;

namespace GP.API.Tower.Services.Implementation
{
    public class ShipPositionUpdatedConsumer : IShipPositionUpdatedConsumer
    {

        private readonly ILogger<ShipPositionUpdatedConsumer> _logger;

        public ShipPositionUpdatedConsumer(ILogger<ShipPositionUpdatedConsumer> logger)
        {
            _logger = logger;
        }

        public Task ConsumerAsync(ShipPositionUpdatedDao shipPositionUpdatedDao)
        {
            _logger.LogInformation("Consume message shipPositionUpdated");
            return Task.CompletedTask;
        }
    }
}
