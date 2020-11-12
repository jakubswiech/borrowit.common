using System;
using System.Threading;
using System.Threading.Tasks;
using BorrowIt.Common.Rabbit.Abstractions;
using BorrowIt.Common.Rabbit.Helpers;
using RawRabbit;

namespace BorrowIt.Common.Rabbit.Implementations
{
    public class BusPublisher : IBusPublisher
    {
        private readonly IBusClient _busClient;

        public BusPublisher(IBusClient busClient)
        {
            _busClient = busClient;
        }
        
        public async Task PublishAsync<TMessage>(TMessage message) where TMessage : IMessage
        {
            await _busClient.PublishAsync(message, ctx => ctx.UsePublishConfiguration(cfg =>
            {
                cfg.OnDeclaredExchange(x => x.WithName(PathHelper.GetPath<TMessage>()));
                cfg.WithRoutingKey(PathHelper.GetPath<TMessage>());
            }));
        }
    }
}