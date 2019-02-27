using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub.Entities
{
    public class WhisperTags
    {
        [ModelProperty("login")]
        public Utf8String UserName { get; set; }
        [ModelProperty("display_name")]
        public Utf8String DisplayName { get; set; }
        [ModelProperty("color")]
        public Utf8String Color { get; set; }
        [ModelProperty("emotes")]
        public Emote[] Emotes { get; set; }
        [ModelProperty("badges")]
        public Badge[] Badges { get; set; }
    }
}
