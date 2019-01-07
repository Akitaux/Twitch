using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class Game
    {
        [ModelProperty("id")]
        public ulong Id { get; set; }
        [ModelProperty("name")]
        public Utf8String Name { get; set; }
        [ModelProperty("box_art_url")]
        public Utf8String BoxArtUrl { get; set; }
    }
}
