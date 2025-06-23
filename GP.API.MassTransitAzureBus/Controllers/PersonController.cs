using GP.LIB.Messages.Interface;
using GP.MSG.MassTransitAzureBus;
using Microsoft.AspNetCore.Mvc;

namespace GP.API.MassTransitAzureBus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonMessagePublisher _personMessagePublisher;

        public PersonController(IPersonMessagePublisher personMessagePublisher, ILogger<PersonController> logger)
        {
            _personMessagePublisher = personMessagePublisher;
            _logger = logger;
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] PersonMessage personMessage)
        {
            _logger.LogInformation("Received person message: {@PersonMessage}", personMessage);

            await _personMessagePublisher.PublishAsync(personMessage);

            return Ok(new { Message = "Person message published successfully." });
        }
    }
}
