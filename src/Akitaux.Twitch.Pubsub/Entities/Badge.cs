using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub.Entities
{
    public class Badge
    {
        [ModelProperty("id")]
        public Utf8String Id { get; set; }
        [ModelProperty("version")]
        public int Version { get; set; }
    }
}
