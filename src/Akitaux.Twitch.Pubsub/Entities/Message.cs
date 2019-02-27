using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub.Entities
{
    public class Message
    {
        [ModelProperty("message")]
        public Utf8String Content { get; set; }
        [ModelProperty("emotes")]
        public Emote[] Emotes { get; set; }
    }
}
