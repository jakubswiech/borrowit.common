using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using BorrowIt.Api.Domain;
using BorrowIt.Api.Entities;
using BorrowIt.Api.Messages;
using BorrowIt.Common.Domain.Repositories;
using BorrowIt.Common.Mongo.IoC;
using BorrowIt.Common.Rabbit.Abstractions;
using BorrowIt.Common.Rabbit.Implementations;
using BorrowIt.Common.Rabbit.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BorrowIt.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new RawRabbitModule(Configuration));
            builder.RegisterModule(new MongoDbModule(Configuration, "mongoDb"));
            builder.Register(ctx => new MapperConfiguration(x => x.CreateMap<Test, TestEntity>()).CreateMapper())
                .As<IMapper>().SingleInstance();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            
            app.UseRabbitMq()
                .SubscribeMessage<TestMessage>();

            
            var publisher = app.ApplicationServices.GetService<IBusPublisher>();

            publisher.PublishAsync(new TestMessage() {Name = "test message"});

            var genericRepo = app.ApplicationServices.GetService<IGenericRepository<Test, TestEntity>>();

            var id = Guid.NewGuid();
            genericRepo.CreateAsync(new Test("test", id)).GetAwaiter().GetResult();
            var test = genericRepo.GetWithExpressionAsync(x => x.Id == id).GetAwaiter().GetResult().SingleOrDefault();
            
            Console.WriteLine(test.Name);

        }
    }
}