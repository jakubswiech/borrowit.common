using System;

namespace BorrowIt.Common.Domain
{
    public abstract class DomainModel
    {
        public Guid Id { get; protected set; }
    }
}