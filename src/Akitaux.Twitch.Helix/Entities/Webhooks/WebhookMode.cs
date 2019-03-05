using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    [ModelStringEnum]
    public enum WebhookMode
    {
        [ModelEnumValue("subscribe")]
        Subscribe,
        [ModelEnumValue("unsubscribe")]
        Unsubscribe
    }
}
