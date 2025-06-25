using GP.LIB.Messages.Interface;
using GP.MSG.MassTransitAzureBus.Ship;

namespace GP.API.Ship.Services.Implementation
{
    public class ShipService : IShipService
    {
        private readonly IMessagePublisher _publishEndpoint;
        private readonly ILogger<ShipService> _logger;

        public ShipService(IMessagePublisher publishEndpoint, ILogger<ShipService> logger)
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public async Task UpdatePositionAsync(string mmsi, double lat, double lon, double speed, int heading)
        {
            _logger.LogInformation("Publish");
            var message = new ShipPositionUpdated()
            {
                MMSI = mmsi,
                Heading = heading,
                Latitude = lat,
                Longitude = lon,
                Speed = speed
            };           
            await _publishEndpoint.PublishAsync(message);
        }
    }
}
