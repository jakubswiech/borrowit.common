using RawRabbit.Configuration;

namespace BorrowIt.Common.Rabbit
{
    public class BorrowItRawRabbitConfiguration : RawRabbitConfiguration
    {
        public BorrowItRawRabbitConfiguration()
        {
        }

        public string QueueNameSuffix { get; set; }
    }
}
