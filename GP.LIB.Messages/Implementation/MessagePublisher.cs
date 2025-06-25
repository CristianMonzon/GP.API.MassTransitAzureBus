using GP.LIB.Messages.Interface;
using GP.MSG.MassTransitAzureBus;
using GP.MSG.MassTransitAzureBus.Ship;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace GP.LIB.Messages.Implementation
{
    public class MessagePublisher : IMessagePublisher
    {

        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<MessagePublisher> _logger;

        public MessagePublisher(IPublishEndpoint publishEndpoint, ILogger<MessagePublisher> logger)
        {
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }

        public async Task PublishAsync(ShipMessage message)
        {
            _logger.LogInformation("Publishing person message...");
            await _publishEndpoint.Publish(message);
            _logger.LogInformation("Message published.");
        }

        public async Task PublishAsync(ShipPositionUpdated message)
        {
            _logger.LogInformation("Publishing person message...");
            await _publishEndpoint.Publish(message);
            _logger.LogInformation("Message published.");
        }
    }
}
