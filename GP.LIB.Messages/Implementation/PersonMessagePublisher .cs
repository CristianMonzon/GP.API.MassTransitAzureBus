using GP.LIB.Messages.Interface;
using GP.MSG.MassTransitAzureBus;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace GP.LIB.Messages.Implementation
{
    public class PersonMessagePublisher : IPersonMessagePublisher
    {

        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<PersonMessagePublisher> _logger;

        public PersonMessagePublisher(IPublishEndpoint publishEndpoint, ILogger<PersonMessagePublisher> logger)
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public async Task PublishAsync(PersonMessage message)
        {
            _logger.LogInformation("Publishing person message...");
            await _publishEndpoint.Publish(message);
            _logger.LogInformation("Message published.");
        }
    }
}
