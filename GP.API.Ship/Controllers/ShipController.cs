using GP.API.Ship.Dao;
using GP.API.Ship.Services;
using GP.LIB.Messages.Implementation;
using GP.LIB.Messages.Interface;
using GP.MSG.MassTransitAzureBus.Ship;
using Microsoft.AspNetCore.Mvc;

namespace GP.API.Ship.Controllers        
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v1/[controller]")]
    public class ShipController : ControllerBase
    {
        private readonly ILogger<ShipController> _logger;
        private readonly IShipPositionService _shipPositionService;
        private readonly IShipService _shipService;

        public ShipController(IMessagePublisher shipMessagePublisher, 
            ILogger<ShipController> logger, 
            IShipPositionService shipPositionService,
            IShipService shipService
            )
        {
            _shipService = shipService;
            _shipPositionService = shipPositionService;
            _logger = logger;
        }

        /// <summary>
        /// Gets the ships.
        /// <remarks>
        /// Call example:
        ///     GET: api/v1/ship
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [MapToApiVersion("1")]
        public async Task<ActionResult<IEnumerable<GP.API.Ship.Dao.ShipDao>>> GetShips()
        {
            var ships = await _shipService.GetAllAsync();
            return Ok(ships);
        }

        /// <summary>
        /// Create or Update the ship. 
        /// POST: api/v1/ship/CreateOrUpdate
        /// </summary>
        /// <param name="ship">The ship.</param>
        /// <returns></returns>
        [HttpPost("CreateOrUpdate")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<ShipCreateOrUpdateResponse>>> CreateOrUpdateShip([FromBody] ShipRequest shipRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var shipDao = new ShipDao()
            {
                MMSI = shipRequest.MMSI,
                ShipName = shipRequest.ShipName,
                Flag = shipRequest.Flag,
                Draught = shipRequest.Draught,
                Length = shipRequest.Length,
            };

            var response = await _shipService.CreateOrUpdateShip(shipDao);

            if (response.IsOK)
                return Ok(response.Value.ToResponse());
            else
                return BadRequest(response.ErrorMessage);
        }

        /// <summary>
        /// Send Ship Position Updated message
        /// </summary>
        /// <remarks>
        /// Call example:
        ///     POST /api/v1/Ship/ShipPositionUpdatedMessage
        /// </remarks>
        [HttpPost("ShipPositionUpdatedMessage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Post([FromBody] ShipPositionUpdatedMessage message)
        {
            _logger.LogInformation("Received ship message: {@ShipPositionUpdatedMessage}", message);

            var shipPositionDao = new ShipPositionDao
            {
                MMSI = message.MMSI,
                Speed = message.Speed,
                Latitude = message.Latitude,
                Longitude = message.Longitude,
                Heading = message.Heading,
                EventDate = new DateTimeOffset()
            };

            await _shipPositionService.RegisterShipPositionAsync(shipPositionDao);

            return Ok(new { Message = "Ship Position Updated Message published successfully." });
        }
    }
}