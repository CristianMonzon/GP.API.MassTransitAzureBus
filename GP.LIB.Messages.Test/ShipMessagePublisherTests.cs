using GP.MSG.MassTransitAzureBus;
using MassTransit;
using Microsoft.Extensions.Logging;
using NSubstitute;
using GP.LIB.Messages.Interface;
using GP.LIB.Messages.Implementation;

namespace GP.API.Tests
{
    public class ShipMessagePublisherTests
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ILogger<MessagePublisher> logger;
        private readonly IMessagePublisher publisher;

        public ShipMessagePublisherTests()
        {
            publishEndpoint = Substitute.For<IPublishEndpoint>();
            logger = Substitute.For<ILogger<MessagePublisher>>();
            publisher = new MessagePublisher(publishEndpoint, logger);
        }

        [Fact]
        public async Task PublishAsync_ShouldCallPublishOnEndpoint()
        {
            // Arrange
            var message = new ShipMessage();            

            // Act
            await publisher.PublishAsync(message);

            // Assert
            await publishEndpoint.Received(1).Publish(message, default);
        }
    }
}
  
