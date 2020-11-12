using System;
using Newtonsoft.Json;
using JsonSerializer = RawRabbit.Serialization.JsonSerializer;

namespace BorrowIt.Common.Rabbit.Implementations
{
    public class RabbitSerializer : JsonSerializer
    {
        public RabbitSerializer() : base(Newtonsoft.Json.JsonSerializer.Create(new JsonSerializerSettings 
        {
            TypeNameHandling = TypeNameHandling.None,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
        }))
        {
            
        }
    }
}