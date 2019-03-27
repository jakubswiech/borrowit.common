using System.Threading.Tasks;
using BorrowIt.Common.Infrastructure.Abstraction.Commands;

namespace BorrowIt.Common.Infrastructure.Abstraction
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}