using RestEase;
using System.Net.Http;
using Voltaic.Serialization.Json;

namespace Akitaux.Twitch.Rest
{
    // TODO: RestEase converts to UTF16 but we support reading the UTF8 byte stream
    internal class WumpusResponseDeserializer : ResponseDeserializer
    {
        private readonly JsonSerializer _serializer;

        public WumpusResponseDeserializer(JsonSerializer serializer)
        {
            _serializer = serializer;
        }

        public override T Deserialize<T>(string content, HttpResponseMessage response, ResponseDeserializerInfo info)
            => _serializer.ReadUtf16<T>(content); // TODO: Why is this not bytes?
    }
}
