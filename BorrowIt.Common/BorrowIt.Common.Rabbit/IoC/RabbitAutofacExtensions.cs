using System;
using System.Threading;
using BorrowIt.Common.Rabbit.Abstractions;
using BorrowIt.Common.Rabbit.Implementations;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using RawRabbit.vNext.Disposable;

namespace BorrowIt.Common.Rabbit.IoC
{
    public static class RabbitAutofacExtensions
    {
        public static IBusSubscriber UseRabbitMq(this IApplicationBuilder app)
            => new BusSubscriber(app);

    }
}