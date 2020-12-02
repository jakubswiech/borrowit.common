using System;
using System.Linq;
using System.Threading;
using BorrowIt.Common.Rabbit.Abstractions;
using BorrowIt.Common.Rabbit.Attributes;
using BorrowIt.Common.Rabbit.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;

namespace BorrowIt.Common.Rabbit.Implementations
{
    public class BusSubscriber : IBusSubscriber
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IBusClient _busClient;
        private readonly BorrowItRawRabbitConfiguration _rawRabbitConfiguration;

        public BusSubscriber(IApplicationBuilder app)
        {
            _serviceProvider = app.ApplicationServices;
            _busClient = _serviceProvider.GetService<IBusClient>();
            _rawRabbitConfiguration = _serviceProvider.GetService<BorrowItRawRabbitConfiguration>();
        }

        public IBusSubscriber SubscribeMessage<TMessage>() where TMessage : IMessage
        {
            var messageHandler = _serviceProvider.GetService<IMessageHandler<TMessage>>();
            _busClient.SubscribeAsync<TMessage>(async (msg) =>
                {
                    await messageHandler.HandleMessageAsync(msg, CancellationToken.None);
                }, ctx =>
                {
                    ctx.UseSubscribeConfiguration(cfg =>
                    {
                        cfg.Consume(x => x.WithRoutingKey(PathHelper.GetPath<TMessage>()));
                        cfg.OnDeclaredExchange(x => x.WithName(PathHelper.GetPath<TMessage>()));
                        cfg.FromDeclaredQueue(x => x.WithName(PathHelper.GetPath<TMessage>()).WithNameSuffix(_rawRabbitConfiguration.QueueNameSuffix));
                    });
                });

            return this;
        }

        
    }
}