using System.Threading.Tasks;
using BorrowIt.Common.Infrastructure.Abstraction.DTOs;
using BorrowIt.Common.Infrastructure.Abstraction.Queries;

namespace BorrowIt.Common.Infrastructure.Abstraction
{
    public interface IQueryDispatcher
    {
        Task<TDto> DispatchQueryAsync<TDto, TQuery>(TQuery query) where TQuery : IQuery where TDto : IDto;
    }
}