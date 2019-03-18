using System;

namespace BorrowIt.Common.Mongo.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MongoEntityAttribute : Attribute
    {
        public string TableName { get; private set; }

        public MongoEntityAttribute(string tableName)
        {
            SetTableName(tableName);
        }

        private void SetTableName(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException(nameof(tableName));
            }

            TableName = tableName;
        }
    }
}