using System;
using Akitaux.Twitch.Pubsub.Entities;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub.Events
{
    public class CommerceEvent
    {
        [ModelProperty("user_name")]
        public Utf8String UserName { get; set; }
        [ModelProperty("display_name")]
        public Utf8String DisplayName { get; set; }
        [ModelProperty("channel_name")]
        public Utf8String ChannelName { get; set; }
        [ModelProperty("user_id")]
        public ulong UserId { get; set; }
        [ModelProperty("channel_id")]
        public ulong ChannelId { get; set; }
        [ModelProperty("time")]
        public DateTime Timestamp { get; set; }
        [ModelProperty("item_image_url")]
        public Utf8String ItemImageUrl { get; set; }
        [ModelProperty("item_description")]
        public Utf8String ItemDescription { get; set; }
        [ModelProperty("supports_channel")]
        public bool SupportsChannel { get; set; }
        [ModelProperty("purchase_message")]
        public Message PurchaseMessage { get; set; }
    }
}
