using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public enum WebhookMode
    {
        [ModelEnumValue("subscribe")]
        Subscribe,
        [ModelEnumValue("unsubscribe")]
        Unsubscribe
    }
}
