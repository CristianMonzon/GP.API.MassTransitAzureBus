using GP.API.Tower.Dao;
using GP.API.Tower.Services;
using Microsoft.AspNetCore.Mvc;

namespace GP.API.Tower.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v1/[controller]")]
    public class ShipPositionController : ControllerBase
    {
        private readonly IShipPositionService _shipPositionService;
        private readonly ILogger<ShipPositionController> _logger;
        public ShipPositionController(IShipPositionService shipPositionService, ILogger<ShipPositionController> logger)
        {
            _shipPositionService = shipPositionService;
            _logger = logger;
        }

        /// <summary>
        /// Gets the Ship Position
        /// <remarks>
        /// Call example:
        ///     GET: api/v1/ShipPosition
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [MapToApiVersion("1")]
        public async Task<ActionResult<IEnumerable<ShipPositionResponse>>> GetShips()
        {
            var shipPositions = await _shipPositionService.GetAllAsync();
            return Ok(shipPositions.Select(c => c.ToResponse()).ToList());
        }
    }
}