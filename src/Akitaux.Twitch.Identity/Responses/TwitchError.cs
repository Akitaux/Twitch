using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Identity.Responses
{
    public class TwitchError
    {
        [ModelProperty("error")]
        public Utf8String Error { get; set; }
        [ModelProperty("status")]
        public int Status { get; set; }
        [ModelProperty("message")]
        public Utf8String Message { get; set; }
    }
}
