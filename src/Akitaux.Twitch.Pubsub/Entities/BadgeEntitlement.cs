using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub
{
    public class BadgeEntitlement
    {
        [ModelProperty("new_version")]
        public int NewVersion { get; set; }
        [ModelProperty("previous_version")]
        public int PreviousVersion { get; set; }
    }
}
