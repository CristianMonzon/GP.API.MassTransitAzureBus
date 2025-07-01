using GP.API.Ship.Dao;
using GP.LIB.Messages.Implementation;
using GP.LIB.Messages.Interface;
using GP.MSG.MassTransitAzureBus.Ship;

namespace GP.API.Ship.Services.Implementation
{
    public class ShipPositionService : IShipPositionService
    {
        private readonly IMessagePublisher _publishEndpoint;
        private readonly ILogger<ShipPositionService> _logger;

        public ShipPositionService(IMessagePublisher publishEndpoint, ILogger<ShipPositionService> logger)
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        /// <summary>
        /// Registers the ship position asynchronous.
        /// </summary>
        /// <param name="shipPositionDao">The ship position DAO.</param>
        /// <returns></returns>
        public async Task<Result<ShipPositionDao>> RegisterShipPositionAsync(ShipPositionDao shipPositionDao)
        {
            _logger.LogInformation("registerShipPositionAsync ShipPosition message");
            var result = new Result<ShipPositionDao>();
            try
            {
                var message = new ShipPositionUpdatedMessage
                {
                    MMSI = shipPositionDao.MMSI,
                    Speed = shipPositionDao.Speed,
                    Latitude = shipPositionDao.Longitude,
                    Longitude = shipPositionDao.Longitude,
                    Heading = shipPositionDao.Heading,
                    EventDate = new DateTimeOffset()
                };

                await _publishEndpoint.PublishAsync(message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error RegisterShipPositionAsync {ex.Message}");
                result.SetError(ex);
            }
            return result;
        }
    }
}