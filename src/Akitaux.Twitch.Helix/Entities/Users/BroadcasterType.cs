using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public enum BroadcasterType
    {
        None = -1,
        [ModelEnumValue("affiliate")]
        Affiliate,
        [ModelEnumValue("partner")]
        Partner
    }
}
