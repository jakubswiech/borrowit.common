using System;
using Newtonsoft.Json;
using JsonSerializer = RawRabbit.Serialization.JsonMessageSerializer;

namespace BorrowIt.Common.Rabbit.Implementations
{
    public class RabbitSerializer : JsonSerializer
    {
        public RabbitSerializer() : base(new Newtonsoft.Json.JsonSerializer
        {
            TypeNameHandling = TypeNameHandling.None,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
        })
        {
            
        }
    }
}