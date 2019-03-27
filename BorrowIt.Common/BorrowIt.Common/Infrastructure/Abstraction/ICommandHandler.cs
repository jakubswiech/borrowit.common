using System.Threading.Tasks;
using BorrowIt.Common.Infrastructure.Abstraction.Commands;

namespace BorrowIt.Common.Infrastructure.Abstraction
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}