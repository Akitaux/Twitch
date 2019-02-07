using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class Video
    {
        [ModelProperty("video_id")]
        public ulong Id { get; set; }
        [ModelProperty("markers")]
        public Optional<StreamMarker[]> Markers { get; set; }
    }
}
