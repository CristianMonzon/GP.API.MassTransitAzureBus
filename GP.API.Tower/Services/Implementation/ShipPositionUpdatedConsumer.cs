using GP.API.Tower.Dao;
using GP.API.Tower.Repository;


namespace GP.API.Tower.Services.Implementation
{
    public class ShipPositionUpdatedConsumer : IShipPositionUpdatedConsumer
    {

        private readonly IShipPositionRepository _shipPositionRepository;
        private readonly ILogger<ShipPositionUpdatedConsumer> _logger;

        public ShipPositionUpdatedConsumer(IShipPositionRepository shipPositionRepository,ILogger<ShipPositionUpdatedConsumer> logger)
        {
            _shipPositionRepository = shipPositionRepository;
            _logger = logger;
        }

        public async Task ConsumerAsync(ShipPositionUpdatedDao shipPositionUpdatedDao)
        {
            await _shipPositionRepository.CreateShipPosition(shipPositionUpdatedDao);
            _logger.LogInformation("Consume message shipPositionUpdated");           
        }
    }
}
