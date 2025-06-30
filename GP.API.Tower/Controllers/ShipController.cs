using GP.API.Tower.Dao;
using GP.API.Tower.Model;
using GP.API.Tower.Services;
using GP.LIB.Messages.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace GP.API.Tower.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v1/[controller]")]
    public class ShipController : ControllerBase
    {
        private readonly ILogger<ShipController> _logger;
        private readonly IShipService _shipService;

        public ShipController(IShipService shipService, ILogger<ShipController> logger)
        {
            _shipService = shipService;
            _logger = logger;
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
                Flag = shipRequest.Flag,
                Draught = shipRequest.Draught,
                Length = shipRequest.Length,
                MMSI = shipRequest.MMSI,
                ShipName = shipRequest.ShipName,
            };

            var response = await _shipService.CreateOrUpdateShip(shipDao);

            if (response.IsOK)
                return Ok(response.Value.ToResponse());
            else
                return BadRequest(response.ErrorMessage);
        }

        /// <summary>
        /// Gets the ships.
        /// GET: api/v1/ship
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [MapToApiVersion("1")]
        public async Task<ActionResult<IEnumerable<Ship>>> GetShips()
        {
            var ships = await _shipService.GetAllAsync();
            return Ok(ships);
        }
    }
}
