using System;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class Stream
    {
        [ModelProperty("id")]
        public ulong Id { get; set; }
        [ModelProperty("user_id")]
        public ulong UserId { get; set; }
        [ModelProperty("user_name")]
        public Utf8String UserName { get; set; }
        [ModelProperty("game_id")]
        public ulong GameId { get; set; }
        [ModelProperty("community_ids")]
        public Utf8String[] CommunityIds { get; set; }
        [ModelProperty("type")]
        public Utf8String Type { get; set; }
        [ModelProperty("title")]
        public Utf8String Title { get; set; }
        [ModelProperty("viewer_count")]
        public int ViewerCount { get; set; }
        [ModelProperty("started_at")]
        public DateTime StartedAt { get; set; }
        [ModelProperty("language")]
        public Utf8String Language { get; set; }
        [ModelProperty("thumbnail_url")]
        public Utf8String ThumbnailUrl { get; set; }
        [ModelProperty("tag_ids")]
        public Utf8String[] TagIds { get; set; }
    }
}
