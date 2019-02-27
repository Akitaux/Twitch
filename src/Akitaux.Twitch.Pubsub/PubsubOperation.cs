using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub
{
    public enum PubsubOperation
    {
        Unknown = 0,
        [ModelEnumValue("PING")]
        Ping,
        [ModelEnumValue("PONG")]
        Pong,
        [ModelEnumValue("RECONNECT")]
        Reconnect,
        [ModelEnumValue("LISTEN")]
        Listen,
        [ModelEnumValue("RESPONSE")]
        Response,
        [ModelEnumValue("MESSAGE")]
        Message
    }
}
