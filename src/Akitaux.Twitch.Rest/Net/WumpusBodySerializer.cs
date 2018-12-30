using RestEase;
using System.Net.Http;
using System.Net.Http.Headers;
using Voltaic.Serialization.Json;

namespace Akitaux.Twitch.Rest
{
    internal class WumpusBodySerializer : RequestBodySerializer
    {
        private readonly JsonSerializer _serializer;

        public WumpusBodySerializer(JsonSerializer serializer)
        {
            _serializer = serializer;
        }

        public override HttpContent SerializeBody<T>(T body, RequestBodySerializerInfo info)
        {
            if (body == null)
                return null;

            var arr = _serializer.Write(body).AsSegment();
            var content = new ByteArrayContent(arr.Array, arr.Offset, arr.Count);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }
    }
}
