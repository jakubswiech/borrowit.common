using System.Linq;
using BorrowIt.Common.Rabbit.Abstractions;
using BorrowIt.Common.Rabbit.Attributes;

namespace BorrowIt.Common.Rabbit.Helpers
{
    public static class PathHelper
    {
        public static string GetPath<TMessage>() where TMessage : IMessage
        {
            var messageType = typeof(TMessage);
            var fullName = messageType.Name;

            var attribute = 
                messageType.GetCustomAttributes(typeof(RabbitMessageAttribute), false)
                    .SingleOrDefault() as RabbitMessageAttribute;

            if (attribute == null)
            {
                return messageType.Namespace + "." + fullName;
            }
            else
            {
                return attribute.Name + "." + fullName;
            }
        }
    }
}