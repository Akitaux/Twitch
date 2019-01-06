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
        public Optional<string> BroadcasterName { get; set; }
        [ModelProperty("creator_id")]
        public Optional<ulong> CreatorId { get; set; }
        [ModelProperty("creator_name")]
        public Optional<string> CreatorName { get; set; }
        [ModelProperty("video_id")]
        public Optional<ulong> VideoId { get; set; }
        [ModelProperty("game_id")]
        public Optional<ulong> GameId { get; set; }
        [ModelProperty("language")]
        public Optional<string> Language { get; set; }
        [ModelProperty("title")]
        public Optional<string> Title { get; set; }
        [ModelProperty("view_count")]
        public Optional<int> ViewCount { get; set; }
        [ModelProperty("created_at")]
        public Optional<DateTime> CreatedAt { get; set; }

        [ModelProperty("url")]
        public Optional<string> Url { get; set; }
        [ModelProperty("embed_url")]
        public Optional<string> EmbedUrl { get; set; }
        [ModelProperty("edit_url")]
        public Optional<string> EditUrl { get; set; }
        [ModelProperty("thumbnail_url")]
        public Optional<string> ThumbnailUrl { get; set; }
    }
}
