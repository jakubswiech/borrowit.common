using System.Collections.Generic;
using Autofac;
using BorrowIt.Common.Rabbit.Abstractions;
using BorrowIt.Common.Rabbit.Implementations;
using Microsoft.Extensions.Configuration;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.DependencyInjection.Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit.Serialization;
using RawRabbit.vNext;

namespace BorrowIt.Common.Rabbit.IoC
{
    public class RawRabbitModule : Module
    {
        private readonly IConfiguration _configuration;

        public RawRabbitModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var client = BusClientFactory.CreateDefault(ctx =>
                {
                    ctx.AddJsonFile("rawrabbit.json");
                },
                ioc => ioc.AddSingleton<IMessageSerializer, RabbitSerializer>()
                );
            builder.Register(ctx => client).As<IBusClient>().SingleInstance();
            builder.RegisterType<BusPublisher>().As<IBusPublisher>();
        }
    }
}