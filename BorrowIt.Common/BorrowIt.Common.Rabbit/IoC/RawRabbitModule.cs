using System.Collections.Generic;
using Autofac;
using BorrowIt.Common.Rabbit.Abstractions;
using BorrowIt.Common.Rabbit.Implementations;
using Microsoft.Extensions.Configuration;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.DependencyInjection.Autofac;
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
            var options = new RawRabbitConfiguration();
            options.Hostnames = new List<string>();
            _configuration.GetSection("rabbitmq").Bind(options);
            var client = BusClientFactory.CreateDefault(options);
            builder.Register(ctx => client).As<IBusClient>().SingleInstance();
            builder.RegisterType<BusPublisher>().As<IBusPublisher>();
        }
    }
}