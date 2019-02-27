using System;
using Akitaux.Twitch.Pubsub.Entities;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub.Events
{
    public class ChannelSubscribeEvent
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
        [ModelProperty("sub_plan")]
        public Utf8String SubPlan { get; set; }
        [ModelProperty("sub_plan_name")]
        public Utf8String SubPlanName { get; set; }
        [ModelProperty("cumulative-months")]
        public int CumulativeMonths { get; set; }
        [ModelProperty("streak-months")]
        public int StreakMonths { get; set; }
        [ModelProperty("context")]
        public Utf8String Context { get; set; }
        [ModelProperty("sub_message")]
        public Message SubMessage { get; set; }

        // Gifted sub
        [ModelProperty("recipient_id")]
        public Optional<ulong> RecipientId { get; set; }
        [ModelProperty("recipient_user_name")]
        public Optional<Utf8String> RecipientUserName { get; set; }
        [ModelProperty("recipient_display_name")]
        public Optional<Utf8String> RecipientDisplayName { get; set; }
    }
}
