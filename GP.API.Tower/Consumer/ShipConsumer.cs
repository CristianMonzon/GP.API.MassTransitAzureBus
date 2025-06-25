using GP.API.Tower.Services;
using GP.LIB.Messages.Dto;
using GP.LIB.Messages.Interface;
using GP.MSG.MassTransitAzureBus;
using GP.MSG.MassTransitAzureBus.Ship;
using MassTransit;


namespace GP.API.Tower.Consumer
{
    public class ShipConsumer : IConsumer<ShipPositionUpdated>
    {
        private readonly ILogger<ShipConsumer> _logger;
        private readonly IShipPositionUpdatedConsumer _shipMessageConsumer;

        public ShipConsumer(IShipPositionUpdatedConsumer shipMessageConsumer, ILogger<ShipConsumer> logger)
        {
            _shipMessageConsumer = shipMessageConsumer;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ShipPositionUpdated> context)
        {
            _logger.LogInformation("Received ship message: {@PersonMessage}", context.Message);

            var shipPositionUpdatedDao = new ShipPositionUpdatedDao()
            {
                Heading = context.Message.Heading,
                Latitude = context.Message.Latitude,
                Longitude = context.Message.Longitude,
                MMSI = context.Message.MMSI,
                Speed = context.Message.Speed
            };
            
            await _shipMessageConsumer.ConsumerAsync(shipPositionUpdatedDao);
        }
    }
}
