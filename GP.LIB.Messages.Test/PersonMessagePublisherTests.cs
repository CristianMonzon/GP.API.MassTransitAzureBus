using GP.MSG.MassTransitAzureBus;
using MassTransit;
using Microsoft.Extensions.Logging;
using NSubstitute;
using GP.LIB.Messages.Interface;
using GP.LIB.Messages.Impl;

namespace GP.API.Tests
{
    public class PersonMessagePublisherTests
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ILogger<PersonMessagePublisher> logger;
        private readonly IPersonMessagePublisher publisher;

        public PersonMessagePublisherTests()
        {
            publishEndpoint = Substitute.For<IPublishEndpoint>();
            logger = Substitute.For<ILogger<PersonMessagePublisher>>();
            publisher = new PersonMessagePublisher(publishEndpoint, logger);
        }

        [Fact]
        public async Task PublishAsync_ShouldCallPublishOnEndpoint()
        {
            // Arrange
            var message = new PersonMessage
            {
                FirstName = "Cristian",
                LastName = "Monzon",
                BirthDay = new DateTime(1945, 6, 5)
            };

            // Act
            await publisher.PublishAsync(message);

            // Assert
            await publishEndpoint.Received(1).Publish(message, default);
        }
    }
}
   
