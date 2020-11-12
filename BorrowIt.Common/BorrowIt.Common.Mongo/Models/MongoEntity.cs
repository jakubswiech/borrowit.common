using System;
using BorrowIt.Common.Infrastructure.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BorrowIt.Common.Mongo.Models
{
    public abstract class MongoEntity : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
    }
}