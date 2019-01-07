using System;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class Clip
    {
        [ModelProperty("id")]
        public string Id { get; set; }

        [ModelProperty("broadcaster_id")]
        public Optional<ulong> BroadcasterId { get; set; }
        [ModelProperty("broadcaster_name")]
        public Optional<Utf8String> BroadcasterName { get; set; }
        [ModelProperty("creator_id")]
        public Optional<ulong> CreatorId { get; set; }
        [ModelProperty("creator_name")]
        public Optional<Utf8String> CreatorName { get; set; }
        [ModelProperty("video_id")]
        public Optional<ulong> VideoId { get; set; }
        [ModelProperty("game_id")]
        public Optional<ulong> GameId { get; set; }
        [ModelProperty("language")]
        public Optional<Utf8String> Language { get; set; }
        [ModelProperty("title")]
        public Optional<Utf8String> Title { get; set; }
        [ModelProperty("view_count")]
        public Optional<int> ViewCount { get; set; }
        [ModelProperty("created_at")]
        public Optional<DateTime> CreatedAt { get; set; }

        [ModelProperty("url")]
        public Optional<Utf8String> Url { get; set; }
        [ModelProperty("embed_url")]
        public Optional<Utf8String> EmbedUrl { get; set; }
        [ModelProperty("edit_url")]
        public Optional<Utf8String> EditUrl { get; set; }
        [ModelProperty("thumbnail_url")]
        public Optional<Utf8String> ThumbnailUrl { get; set; }
    }
}
