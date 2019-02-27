using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub
{
    [ModelStringEnum]
    public enum PubsubDispatchType
    {
        Unknown = 0,
        [ModelEnumValue("channel-bits-events-v1")]
        BitsV1,
        [ModelEnumValue("channel-bits-events-v2")]
        BitsV2,
        [ModelEnumValue("channel-bits-badge-unlocks")]
        BitsBadgeUnlock,
        [ModelEnumValue("channel-subscribe-events-v1")]
        ChannelSubscriptionV1,
        [ModelEnumValue("channel-commerce-events-v1")]
        CommerceV1,
        [ModelEnumValue("whispers")]
        Whisper
    }
}
