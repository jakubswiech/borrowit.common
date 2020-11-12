using System;
using BorrowIt.Common.Mongo.Attributes;
using BorrowIt.Common.Mongo.Models;
using MongoDB.Bson;

namespace BorrowIt.Api.Entities
{
    [MongoEntity("Tests")]
    public class TestEntity : MongoEntity
    {
        public string Name { get; set; }
    }
}