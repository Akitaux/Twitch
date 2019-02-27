using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub.Entities
{
    public class User
    {
        [ModelProperty("id")]
        public ulong Id { get; set; }
        [ModelProperty("username")]
        public Utf8String UserName { get; set; }
        [ModelProperty("display_name")]
        public Utf8String DisplayName { get; set; }
        [ModelProperty("color")]
        public Utf8String Color { get; set; }
        [ModelProperty("badges")]
        public Badge[] Badges { get; set; }
    }
}
