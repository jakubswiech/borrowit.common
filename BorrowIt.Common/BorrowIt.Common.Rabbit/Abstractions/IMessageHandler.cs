using System.Threading;
using System.Threading.Tasks;

namespace BorrowIt.Common.Rabbit.Abstractions
{
    public interface IMessageHandler<TMessage> where TMessage : IMessage
    {
        Task HandleMessageAsync(TMessage message, CancellationToken token);
    }
}