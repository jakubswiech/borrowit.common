using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BorrowIt.Common.Infrastructure.Entities;

namespace BorrowIt.Common.Domain.Repositories
{
    public interface IGenericRepository<TDomainModel, TEntity> where TDomainModel : DomainModel where TEntity : IEntity
    {
        Task CreateAsync(TDomainModel aggregate);
        Task UpdateAsync(TDomainModel aggregate);
        Task RemoveAsync(TDomainModel aggregate);
        Task<IEnumerable<TDomainModel>> GetAllAsync();
        Task<TDomainModel> GetAsync(Expression<Func<TDomainModel, bool>> predicate);
        Task<TDomainModel> GetAsync(Guid id);
    }
}