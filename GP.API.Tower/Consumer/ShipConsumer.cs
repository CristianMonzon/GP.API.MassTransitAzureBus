using GP.API.Tower.Dao;
using GP.API.Tower.Services;
using GP.MSG.MassTransitAzureBus.Ship;
using MassTransit;

namespace GP.API.Tower.Consumer
{
    public class ShipConsumer : IConsumer<ShipPositionUpdatedMessage>
    {
        private readonly ILogger<ShipConsumer> _logger;
        private readonly IShipPositionUpdatedConsumer _shipMessageConsumer;

        public ShipConsumer(IShipPositionUpdatedConsumer shipMessageConsumer, ILogger<ShipConsumer> logger)
        {
            _shipMessageConsumer = shipMessageConsumer;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ShipPositionUpdatedMessage> context)
        {
            _logger.LogInformation("Receiving ship message: {@ShipPositionUpdated}", context.Message);
            try
            {
                var shipPositionUpdatedDao = new ShipPositionUpdatedDao()
                {
                    MMSI = context.Message.MMSI,
                    Heading = context.Message.Heading,
                    Latitude = context.Message.Latitude,
                    Longitude = context.Message.Longitude,
                    Speed = context.Message.Speed
                };
                await _shipMessageConsumer.ConsumerAsync(shipPositionUpdatedDao);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error receiving Ship Position Updated Message: {context.Message} * Exception : {ex.Message}");
                throw;
            }
        }
    }
}
