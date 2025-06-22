using MassTransit;
using GP.API.MassTransitAzure.Messages;


namespace GP.API.MassTransitAzureBus.Consumer
{
    public class PersonConsumer : IConsumer<PersonMessage>
    {
        public Task Consume(ConsumeContext<PersonMessage> context)
        {
            Console.WriteLine($"Received: {context.Message.FirstName} - {context.Message.LastName}");
            return Task.CompletedTask;
        }
    }
}
