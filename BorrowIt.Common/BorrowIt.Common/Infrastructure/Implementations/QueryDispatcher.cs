using System;
using System.Threading.Tasks;
using Autofac;
using BorrowIt.Common.Infrastructure.Abstraction;
using BorrowIt.Common.Infrastructure.Abstraction.DTOs;
using BorrowIt.Common.Infrastructure.Abstraction.Queries;

namespace BorrowIt.Common.Infrastructure.Implementations
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _context;

        public QueryDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public Task<TDto> DispatchQueryAsync<TDto, TQuery>(TQuery query) where TDto : IDto where TQuery : IQuery
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            
            var handler = _context.Resolve<IQueryHandler<TQuery, TDto>>();
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return handler.HandleAsync(query);
        }
    }
}