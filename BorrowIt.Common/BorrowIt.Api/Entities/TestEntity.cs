using System;
using BorrowIt.Common.Mongo.Attributes;
using BorrowIt.Common.Mongo.Models;

namespace BorrowIt.Api.Entities
{
    [MongoEntity("Tests")]
    public class TestEntity : IMongoEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}