using System.Collections.Generic;
using System.Reflection;
using Autofac;
using BorrowIt.Common.Mongo.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Module = Autofac.Module;


namespace BorrowIt.Common.Mongo.IoC
{
    public class MongoDbModule : Module
    {
        private readonly IConfiguration _configuration;

        public MongoDbModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            var options = new MongoDbSettings();
            options.ConnectionString = _configuration["mongoDb:ConnectionString"];
            builder.Register(x => new MongoClient(options.ConnectionString)).As<IMongoClient>().SingleInstance();
            builder.Register(x => x.Resolve<IMongoClient>().GetDatabase(options.DatabaseName)).As<IMongoDatabase>()
                .InstancePerLifetimeScope();
        }
    }
}