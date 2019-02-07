using System;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class StreamMarker
    {
        // Create
        [ModelProperty("id")]
        public string Id { get; set; }
        [ModelProperty("description")]
        public Optional<Utf8String> Description { get; set; }
        [ModelProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [ModelProperty("position_seconds")]
        public int PositionSeconds { get; set; }

        // Get
        [ModelProperty("URL")]
        public Optional<Utf8String> Url { get; set; }
    }
}
