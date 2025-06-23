using GP.LIB.Messages.Dto;

namespace GP.LIB.Messages.Interface
{
    public interface IPersonMessageConsumer
    {
        Task ConsumerAsync(PersonMessageDto personMessageDto);
    }
}
