using System;
using Autofac;
using BorrowIt.Common.Application.Services;
using BorrowIt.Common.Domain.Repositories;
using BorrowIt.Common.Exceptions;

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
            if (!genericRepositoryType.IsAssignableFrom(typeof(IGenericRepository<,>)))
            {
                throw new BusinessLogicException("Type is not assignable to IGenericRepository");
            }

            builder.RegisterGeneric(genericRepositoryType).As(typeof(IGenericRepository<,>)).InstancePerLifetimeScope();

            return builder;
        }
    }
}