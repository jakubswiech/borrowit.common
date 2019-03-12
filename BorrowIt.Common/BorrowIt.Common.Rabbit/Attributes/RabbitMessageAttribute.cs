using System;

namespace BorrowIt.Common.Rabbit.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RabbitMessageAttribute : Attribute
    {
        public string Name { get; private set; }

        public RabbitMessageAttribute(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                Name = name;
            }
        }
    }
}