using System.Buffers;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub.Serialization
{
    public class PubsubJsonSerializer : TwitchJsonSerializer
    {
        public PubsubJsonSerializer(ConverterCollection converters = null, ArrayPool<byte> bytePool = null)
          : base(converters, bytePool)
        {
            _converters.SetDefault<Topic, TopicConverter>();
        }
    }
}
