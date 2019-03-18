using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BorrowIt.Common.Domain;
using BorrowIt.Common.Domain.Repositories;
using BorrowIt.Common.Infrastructure.Entities;
using BorrowIt.Common.Mongo.Attributes;
using BorrowIt.Common.Mongo.Models;
using MongoDB.Driver;

namespace BorrowIt.Common.Mongo.Repositories
{
    public class GenericMongoRepository<TDomainModel, TEntity> : IGenericRepository<TDomainModel, TEntity> 
        where TDomainModel : DomainModel where TEntity : IMongoEntity
    {
        private readonly IMongoCollection<TEntity> _collection;

        public GenericMongoRepository(IMongoDatabase database)
        {
            var mongoEntityAttribute = typeof(TEntity).GetCustomAttributes(typeof(MongoEntityAttribute), false)
                .SingleOrDefault() as MongoEntityAttribute;

            if (mongoEntityAttribute == null)
            {
                throw new ArgumentNullException(nameof(mongoEntityAttribute));
            }
            
            _collection = database.GetCollection<TEntity>(mongoEntityAttribute.TableName);
        }
        
        public Task CreateAsync(TDomainModel aggregate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TDomainModel aggregate)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(TDomainModel aggregate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TDomainModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TDomainModel> GetAsync(Expression<Func<TDomainModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TDomainModel> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}