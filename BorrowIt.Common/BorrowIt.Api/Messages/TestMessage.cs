using BorrowIt.Common.Rabbit.Abstractions;
using BorrowIt.Common.Rabbit.Attributes;

namespace BorrowIt.Api.Messages
{
    [RabbitMessage("test")]
    public class TestMessage : IMessage
    {
        public string Name { get; set; }
    }
}