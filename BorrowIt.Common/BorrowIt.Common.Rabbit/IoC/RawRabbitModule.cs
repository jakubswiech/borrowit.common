using System.IO;
using System.Linq;
using Autofac;
using BorrowIt.Common.Rabbit.Abstractions;
using BorrowIt.Common.Rabbit.Implementations;
using Microsoft.Extensions.Configuration;
using RawRabbit;
using RawRabbit.Configuration;
using Newtonsoft.Json;
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
            var config = JsonConvert.DeserializeObject<RawRabbitConfiguration>(File.ReadAllText(@"./rawrabbit.json"));
            if (config.Hostnames.Any(x => !x.Equals("localhost")))
            {
                config.Hostnames.Remove("localhost");
            }

            var client = BusClientFactory.CreateDefault(config);
            builder.Register(ctx => client).As<IBusClient>().SingleInstance();
            builder.RegisterType<BusPublisher>().As<IBusPublisher>();
        }
    }
}