using System;
using Autofac;
using BorrowIt.Common.Application.Services;
using BorrowIt.Common.Domain.Repositories;
using BorrowIt.Common.Exceptions;
using Serilog;
using Serilog.Events;

namespace BorrowIt.Common.Infrastructure.IoC
{
    public static class BorrowItAutofacExtension
    {
        public static ContainerBuilder AddServices<TService>(this ContainerBuilder builder)
        {
            var assembly = typeof(TService).Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            return builder;
        }

        public static ContainerBuilder AddRepositories<TRepository>(this ContainerBuilder builder)
        {
            var assembly = typeof(TRepository).Assembly;
            
            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            return builder;
        }

        public static ContainerBuilder AddGenericRepository(this ContainerBuilder builder, Type genericRepositoryType)
        {
            builder.RegisterGeneric(genericRepositoryType).As(typeof(IGenericRepository<,>)).InstancePerLifetimeScope();

            return builder;
        }

        public static ContainerBuilder AddSerilog(this ContainerBuilder builder)
        {
            builder.Register<ILogger>((c, p) => new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(LogEventLevel.Warning)
                .WriteTo.File("log-.txt", LogEventLevel.Error, rollingInterval: RollingInterval.Day)
                .CreateLogger()).SingleInstance();

            return builder;
        }
    }
}