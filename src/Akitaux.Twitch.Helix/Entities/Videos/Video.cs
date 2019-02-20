using System;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class Video
    {
        [ModelProperty("video_id")]
        private ulong VideoId { get { return Id; } set { Id = VideoId; } }

        [ModelProperty("id")]
        public ulong Id { get; set; }
        [ModelProperty("user_id")]
        public Optional<ulong> UserId { get; set; }
        [ModelProperty("user_name")]
        public Optional<Utf8String> UserName { get; set; }
        [ModelProperty("title")]
        public Optional<Utf8String> Title { get; set; }
        [ModelProperty("description")]
        public Optional<Utf8String> Description { get; set; }
        [ModelProperty("created_at")]
        public Optional<DateTime> CreatedAt { get; set; }
        [ModelProperty("published_at")]
        public Optional<DateTime> PublishedAt { get; set; }
        [ModelProperty("url")]
        public Optional<Utf8String> Url { get; set; }
        [ModelProperty("thumbnail_url")]
        public Optional<Utf8String> ThumbnailUrl { get; set; }
        [ModelProperty("viewable")]
        public Optional<Utf8String> Viewable { get; set; }
        [ModelProperty("view_count")]
        public Optional<int> ViewCount { get; set; }
        [ModelProperty("language")]
        public Optional<Utf8String> Language { get; set; }
        [ModelProperty("type")]
        public Optional<VideoType> Type { get; set; }
        [ModelProperty("viewable")]
        public Optional<TimeSpan> Duration { get; set; }

        // Get Stream Markers
        [ModelProperty("markers")]
        public Optional<StreamMarker[]> Markers { get; set; }
    }
}
