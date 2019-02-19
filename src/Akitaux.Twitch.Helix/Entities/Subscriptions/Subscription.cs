using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class Subscription
    {
        [ModelProperty("broadcaster_id")]
        public Optional<ulong> BroadcasterId { get; set; }
        [ModelProperty("broadcaster_name")]
        public Optional<Utf8String> BroadcasterName { get; set; }
        [ModelProperty("user_id")]
        public Optional<ulong> UserId { get; set; }
        [ModelProperty("user_name")]
        public Optional<ulong> UserName { get; set; }
        [ModelProperty("plan_name")]
        public Optional<Utf8String> PlanName { get; set; }
        [ModelProperty("tier")]
        public Optional<SubscriptionType> Tier { get; set; }
        [ModelProperty("is_gift")]
        public Optional<bool> IsGift { get; set; }
    }
}
