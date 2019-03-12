namespace BorrowIt.Common.Rabbit.Abstractions
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeMessage<TMessage>() where TMessage : IMessage;
    }
}