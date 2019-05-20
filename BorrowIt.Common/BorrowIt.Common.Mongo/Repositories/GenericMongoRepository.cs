using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using BorrowIt.Common.Domain;
using BorrowIt.Common.Domain.Repositories;
using BorrowIt.Common.Mongo.Attributes;
using BorrowIt.Common.Mongo.Models;
using MongoDB.Driver;

namespace BorrowIt.Common.Mongo.Repositories
{
    public class GenericMongoRepository<TDomainModel, TEntity> : IGenericRepository<TDomainModel, TEntity> 
        where TDomainModel : DomainModel where TEntity : IMongoEntity
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<TEntity> _collection;

        public GenericMongoRepository(IMongoDatabase database, IMapper mapper)
        {
            _mapper = mapper;
            var mongoEntityAttribute = typeof(TEntity).GetCustomAttributes(typeof(MongoEntityAttribute), false)
                .SingleOrDefault() as MongoEntityAttribute;

            if (mongoEntityAttribute == null)
            {
                throw new ArgumentNullException(nameof(mongoEntityAttribute));
            }
            
            _collection = database.GetCollection<TEntity>(mongoEntityAttribute.TableName);
        }
        
        public async Task CreateAsync(TDomainModel aggregate)
        {
            CheckAggregateNotNull(aggregate);
            
            var entity = _mapper.Map<TEntity>(aggregate);
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(TDomainModel aggregate)
        {
            CheckAggregateNotNull(aggregate);
            
            var entity = _mapper.Map<TEntity>(aggregate);

            await _collection.ReplaceOneAsync(x => x.Id == aggregate.Id, entity, 
                new UpdateOptions() {IsUpsert = true});


        }

        public async Task RemoveAsync(TDomainModel aggregate)
        {
            await _collection.DeleteOneAsync(x => x.Id == aggregate.Id);
        }

        public async Task<IEnumerable<TDomainModel>> GetAllAsync()
        {
            var entities = await _collection.AsQueryable().ToListAsync();
            return _mapper.Map<IEnumerable<TDomainModel>>(entities);
        }

        public async Task<IEnumerable<TDomainModel>> GetWithExpressionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await _collection.Find(predicate).ToListAsync();
            return _mapper.Map<IEnumerable<TDomainModel>>(entities);
        }
        
        public async Task<IEnumerable<TDomainModel>> GetWithExpressionAsync(FilterDefinition<TEntity> filter)
        {
            var entities = await _collection.Find(filter).ToListAsync();
            return _mapper.Map<IEnumerable<TDomainModel>>(entities);
        }

        public async Task<TDomainModel> GetAsync(Guid id)
        {
            var entity = await _collection.Find(x => x.Id.Equals(id)).SingleOrDefaultAsync();
            return _mapper.Map<TDomainModel>(entity);
        }
            
        
        private void CheckAggregateNotNull(TDomainModel aggregate)
        {
            if (aggregate == null)
            {
                throw new ArgumentNullException(nameof(aggregate));
            }
        }
    }
}