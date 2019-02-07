using System;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class Stream
    {
        // Get Markers
        [ModelProperty("user_id")]
        public ulong UserId { get; set; }
        [ModelProperty("user_name")]
        public Utf8String UserName { get; set; }
        [ModelProperty("videos")]
        public Optional<Video[]> Videos { get; set; }

        // Get Streams
        [ModelProperty("id")]
        public Optional<ulong> Id { get; set; }
        [ModelProperty("game_id")]
        public Optional<ulong> GameId { get; set; }
        [ModelProperty("community_ids")]
        public Optional<Utf8String[]> CommunityIds { get; set; }
        [ModelProperty("type")]
        public Optional<Utf8String> Type { get; set; }
        [ModelProperty("title")]
        public Optional<Utf8String> Title { get; set; }
        [ModelProperty("viewer_count")]
        public Optional<int> ViewerCount { get; set; }
        [ModelProperty("started_at")]
        public Optional<DateTime> StartedAt { get; set; }
        [ModelProperty("language")]
        public Optional<Utf8String> Language { get; set; }
        [ModelProperty("thumbnail_url")]
        public Optional<Utf8String> ThumbnailUrl { get; set; }
        [ModelProperty("tag_ids")]
        public Optional<Utf8String[]> TagIds { get; set; }
    }
}
