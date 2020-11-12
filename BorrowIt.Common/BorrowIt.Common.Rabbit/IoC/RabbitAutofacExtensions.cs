using BorrowIt.Common.Rabbit.Abstractions;
using BorrowIt.Common.Rabbit.Implementations;
using Microsoft.AspNetCore.Builder;

namespace BorrowIt.Common.Rabbit.IoC
{
    public static class RabbitAutofacExtensions
    {
        public static IBusSubscriber UseRabbitMq(this IApplicationBuilder app)
            => new BusSubscriber(app);

    }
}