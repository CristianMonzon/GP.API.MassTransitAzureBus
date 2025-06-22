using GP.API.MassTransitAzure.Messages;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace GP.API.MassTransitAzureBus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<PersonController> _logger;
        
        public PersonController(ILogger<PersonController> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] PersonMessage personMessage)
        {
            await _publishEndpoint.Publish(personMessage);
            return Ok(new { Message = "Person message published successfully." });

        }
    }
}
