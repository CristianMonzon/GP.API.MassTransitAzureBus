using GP.API.Ship.Services;
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
        private readonly IShipService _shipService;

        public ShipController(IMessagePublisher shipMessagePublisher, ILogger<ShipController> logger, IShipService shipService)
        {
            _shipService = shipService;
            _logger = logger;
        }

        /// <summary>
        /// Send Ship Position Updated message
        /// </summary>
        /// <remarks>
        /// Call example:
        ///   POST /api/v1/Ship/ShipPositionUpdated
        /// </remarks>
        [HttpPost("ShipPositionUpdated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Post([FromBody] ShipPositionUpdated message)
        {
            _logger.LogInformation("Received ship message: {@ShipPositionUpdated}", message);

            await _shipService.UpdatePositionAsync(message.MMSI, message.Latitude, message.Longitude, message.Speed, message.Heading);

            return Ok(new { Message = "Ship Position Updated message published successfully." });
        }
    }
}