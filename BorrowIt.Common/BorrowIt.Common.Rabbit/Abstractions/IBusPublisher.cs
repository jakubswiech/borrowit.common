using System.Threading.Tasks;

namespace BorrowIt.Common.Rabbit.Abstractions
{
    public interface IBusPublisher
    {
        Task PublishAsync<TMessage>(TMessage message) where TMessage : IMessage;
    }
}