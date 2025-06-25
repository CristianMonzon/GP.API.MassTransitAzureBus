using GP.LIB.Messages.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GP.API.Tower.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v1/[controller]")]
    public class ShipController : ControllerBase
    {
        private readonly ILogger<ShipController> _logger;
        private readonly IMessagePublisher _shipMessagePublisher;

        public ShipController(IMessagePublisher shipMessagePublisher, ILogger<ShipController> logger)
        {
            _shipMessagePublisher = shipMessagePublisher;
            _logger = logger;
        }
    }
}
