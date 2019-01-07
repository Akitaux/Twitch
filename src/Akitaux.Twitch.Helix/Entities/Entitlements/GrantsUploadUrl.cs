using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class GrantsUploadUrl
    {
        [ModelProperty("url")]
        public Utf8String Value { get; set; }
    }
}
