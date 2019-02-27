using System;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub.Events
{
    public class BitsEvent
    {
        [ModelProperty("user_name")]
        public Utf8String UserName { get; set; }
        [ModelProperty("channel_name")]
        public Utf8String ChannelName { get; set; }
        [ModelProperty("user_id")]
        public ulong UserId { get; set; }
        [ModelProperty("channel_id")]
        public ulong ChannelId { get; set; }
        [ModelProperty("time")]
        public DateTime Timestamp { get; set; }
        [ModelProperty("chat_message")]
        public Utf8String ChatMessage { get; set; }
        [ModelProperty("bits_used")]
        public int BitsUsed { get; set; }
        [ModelProperty("total_bits_used")]
        public int TotalBitsUsed { get; set; }
        [ModelProperty("context")]
        public Utf8String Context { get; set; }
        [ModelProperty("badge_entitlement")]
        public BadgeEntitlement BadgeEntitlement { get; set; }
    }
}
