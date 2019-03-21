using System.Threading.Tasks;
using BorrowIt.Common.Infrastructure.Abstraction.DTOs;
using BorrowIt.Common.Infrastructure.Abstraction.Queries;

namespace BorrowIt.Common.Infrastructure.Abstraction
{
    public interface IQueryHandler<TQuery, TDto> where TQuery : IQuery where TDto : IDto
    {
        Task<TDto> HandleAsync(TQuery query);
    }
}