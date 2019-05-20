using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BorrowIt.Common.Infrastructure.Entities;
using MongoDB.Driver;

namespace BorrowIt.Common.Domain.Repositories
{
    public interface IGenericRepository<TDomainModel, TEntity> where TDomainModel : DomainModel where TEntity : IEntity
    {
        Task CreateAsync(TDomainModel aggregate);
        Task UpdateAsync(TDomainModel aggregate);
        Task RemoveAsync(TDomainModel aggregate);
        Task<IEnumerable<TDomainModel>> GetAllAsync();
        Task<IEnumerable<TDomainModel>> GetWithExpressionAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TDomainModel>> GetWithExpressionAsync(FilterDefinition<TEntity> filter);
        Task<TDomainModel> GetAsync(Guid id);
    }
}