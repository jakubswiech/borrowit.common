using Autofac;
using BorrowIt.Common.Domain.Repositories;
using BorrowIt.Common.Mongo.Models;
using BorrowIt.Common.Mongo.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Module = Autofac.Module;


namespace BorrowIt.Common.Mongo.IoC
{
    public class MongoDbModule : Module
    {
        private readonly IConfiguration _configuration;
        private readonly string _configurationKey;

        public MongoDbModule(IConfiguration configuration, string configurationKey)
        {
            _configuration = configuration;
            _configurationKey = configurationKey;
        }
        protected override void Load(ContainerBuilder builder)
        {

            var options = new MongoDbSettings()
            {
                ConnectionString = _configuration[$"{_configurationKey}:ConnectionString"],
                DatabaseName = _configuration[$"{_configurationKey}:DatabaseName"]
            };
            
            builder.Register(x => new MongoClient(options.ConnectionString)).As<IMongoClient>().SingleInstance();
            builder.Register(x => x.Resolve<IMongoClient>().GetDatabase(options.DatabaseName))
                .As<IMongoDatabase>();
            builder.RegisterGeneric(typeof(GenericMongoRepository<,>)).As(typeof(IGenericRepository<,>));
            
        }
    }
}