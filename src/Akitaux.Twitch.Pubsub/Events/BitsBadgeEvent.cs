using System;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub.Events
{
    public class BitsBadgeEvent
    {
        [ModelProperty("user_id")]
        public ulong UserId { get; set; }
        [ModelProperty("user_name")]
        public Utf8String UserName { get; set; }
        [ModelProperty("channel_id")]
        public ulong ChannelId { get; set; }
        [ModelProperty("channel_name")]
        public Utf8String ChannelName { get; set; }
        [ModelProperty("badge_tier")]
        public int BadgeTier { get; set; }
        [ModelProperty("chat_message")]
        public Utf8String ChatMessage { get; set; }
        [ModelProperty("time")]
        public DateTime Timestamp { get; set; }
    }
}
