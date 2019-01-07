using System;
using System.Buffers;
using Voltaic.Serialization;
using Voltaic.Serialization.Json;

namespace Akitaux.Twitch
{
    public class TwitchJsonSerializer : JsonSerializer
    {
        public TwitchJsonSerializer(ConverterCollection converters = null, ArrayPool<byte> bytePool = null)
          : base(converters, bytePool)
        {
            _converters.SetDefault<DateTime, DateTimeConverter>();
        }
    }
}
