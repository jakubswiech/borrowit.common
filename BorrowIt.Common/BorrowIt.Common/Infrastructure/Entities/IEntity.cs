using System;

namespace BorrowIt.Common.Infrastructure.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}