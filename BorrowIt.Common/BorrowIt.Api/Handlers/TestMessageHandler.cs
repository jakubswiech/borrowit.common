using System;
using System.Threading;
using System.Threading.Tasks;
using BorrowIt.Api.Messages;
using BorrowIt.Common.Rabbit.Abstractions;

namespace BorrowIt.Api.Handlers
{
    public class TestMessageHandler : IMessageHandler<TestMessage>
    {
        public async Task HandleMessageAsync(TestMessage message, CancellationToken token)
        {
            Console.WriteLine(message.Name);
        }
    }
}