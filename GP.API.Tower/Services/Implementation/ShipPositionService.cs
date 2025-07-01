using GP.API.Tower.Dao;
using GP.API.Tower.Repository;
using GP.LIB.Messages.Implementation;
using GP.LIB.Messages.Interface;
using GP.MSG.MassTransitAzureBus.Ship;

namespace GP.API.Tower.Services.Implementation
{
    public class ShipPositionService : IShipPositionService
    {
        private readonly IShipPositionRepository _shipPositionRepository;
        private readonly IMessagePublisher _publishEndpoint;
        private readonly ILogger<ShipPositionService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipPositionService"/> class.
        /// </summary>
        /// <param name="shipPositionRepository">The ship position repository.</param>
        /// <param name="publishEndpoint">The publish endpoint.</param>
        /// <param name="logger">The logger.</param>
        public ShipPositionService(IShipPositionRepository shipPositionRepository,IMessagePublisher publishEndpoint, ILogger<ShipPositionService> logger)
        {
            _shipPositionRepository = shipPositionRepository;
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        /// <summary>
        /// Consumes the ship position asynchronous.
        /// </summary>
        /// <param name="mmsi">The mmsi.</param>
        /// <param name="lat">The lat.</param>
        /// <param name="lon">The lon.</param>
        /// <param name="speed">The speed.</param>
        /// <param name="heading">The heading.</param>
        /// <returns></returns>
        public async Task<Result<ShipPositionUpdatedDao>> ConsumeShipPositionAsync(string mmsi, double lat, double lon, double speed, int heading)
        {
            _logger.LogInformation("Publish");
            var result = new Result<ShipPositionUpdatedDao>();

            try
            {
                var shipPositionDao = new ShipPositionUpdatedDao
                {
                    MMSI = mmsi,
                    Speed = speed,
                    Latitude = lat,
                    Longitude = lon,
                    Heading = heading,
                    EventDate = new DateTimeOffset()
                };
                await _shipPositionRepository.CreateShipPosition(shipPositionDao);

                var message = new ShipPositionUpdatedMessage
                {
                    MMSI = shipPositionDao.MMSI,
                    Speed = shipPositionDao.Speed,
                    Latitude = shipPositionDao.Longitude,
                    Longitude = shipPositionDao.Longitude,
                    Heading = shipPositionDao.Heading,
                    EventDate = shipPositionDao.EventDate,
                };

                await _publishEndpoint.PublishAsync(message);
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }
            return result;
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<IEnumerable<ShipPositionUpdatedDao>> GetAllAsync()
        {
            return await _shipPositionRepository.GetAllAsync();
        }
    }
}
