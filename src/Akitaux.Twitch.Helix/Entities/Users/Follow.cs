using System;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class Follow
    {
        [ModelProperty("from_id")]
        public Optional<ulong> FromId { get; set; }
        [ModelProperty("from_name")]
        public Optional<Utf8String> FromName { get; set; }
        [ModelProperty("to_id")]
        public Optional<ulong> ToId { get; set; }
        [ModelProperty("to_name")]
        public Optional<Utf8String> ToName { get; set; }
        [ModelProperty("followed_at")]
        public Optional<DateTime> FollowedAt { get; set; }
    }
}
