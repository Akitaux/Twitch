using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub
{
    public class RequestParams
    {
        [ModelProperty("topics")]
        public Utf8String[] Topics { get; set; }
        [ModelProperty("auth_token")]
        public Utf8String Token { get; set; }
    }
}
