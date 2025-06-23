using GP.LIB.Messages.Dto;
using GP.LIB.Messages.Interface;
using Microsoft.Extensions.Logging;

namespace GP.LIB.Messages.Impl
{
    public class PersonMessageConsumer : IPersonMessageConsumer
    {

        private readonly ILogger<PersonMessageConsumer> _logger;

        public PersonMessageConsumer(ILogger<PersonMessageConsumer> logger)
        {
            _logger = logger;
        }

        public Task ConsumerAsync(PersonMessageDto personMessageDto)
        {
            _logger.LogInformation($"Received: {personMessageDto.FirstName} - {personMessageDto.LastName}");
            return Task.CompletedTask;
        }
    }
}
