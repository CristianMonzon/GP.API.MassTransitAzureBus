using MassTransit;
using GP.MSG.MassTransitAzureBus;
using GP.API.MassTransitAzureBus.Controllers;
using GP.LIB.Messages.Interface;
using GP.LIB.Messages.Dto;
using GP.LIB.Messages.Impl;


namespace GP.API.MassTransitAzureBus.Consumer
{
    public class PersonConsumer : IConsumer<PersonMessage>
    {
        private readonly ILogger<PersonConsumer> _logger;
        private readonly IPersonMessageConsumer _personMessageConsumer;

        public PersonConsumer(IPersonMessageConsumer personMessageConsumer, ILogger<PersonConsumer> logger)
        {
            _personMessageConsumer = personMessageConsumer;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<PersonMessage> context)
        {
            _logger.LogInformation("Received person message: {@PersonMessage}", context.Message);

            var personMessageDto = new PersonMessageDto()
            {
                BirthDay = context.Message.BirthDay,
                FirstName = context.Message.FirstName,
                LastName = context.Message.LastName
            };
            await _personMessageConsumer.ConsumerAsync(personMessageDto);
        }
    }
}
