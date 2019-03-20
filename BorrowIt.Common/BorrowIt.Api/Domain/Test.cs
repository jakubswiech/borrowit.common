using System;
using BorrowIt.Common.Domain;

namespace BorrowIt.Api.Domain
{
    public class Test : DomainModel
    {
        public string Name { get; set; }

        public Test(string name, Guid id)
        {
            Id = id;
            Name = name;
        }
    }
}