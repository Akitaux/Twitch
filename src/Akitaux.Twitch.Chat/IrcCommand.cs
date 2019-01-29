using Voltaic.Serialization;

namespace Akitaux.Twitch.Chat
{
    public enum IrcCommand
    {
        Unknown = 0,
        [ModelEnumValue("CLEARCHAT")]   // Purge a user’s message(s), typically after a user is banned from chat or timed out.
        ClearChat,
        [ModelEnumValue("CLEARMSG")]    // Single message removal on a channel.
        ClearMessage,
        [ModelEnumValue("HOSTTARGET")]  // Channel starts or stops host mode.
        HostTarget,
        [ModelEnumValue("PRIVMSG")]     // Send a message to a channel.
        Message,

        // Incoming Only
        [ModelEnumValue("PONG")]        // Pong
        Pong,
        [ModelEnumValue("MODE")]        // Gain/lose moderator (operator) status in a channel.
        Mode,
        [ModelEnumValue("NAMES")]       // List current chatters in a channel.
        Names,
        [ModelEnumValue("NOTICE")]      // General notices from the server.
        Notice,
        [ModelEnumValue("RECONNECT")]   // Rejoin channels after a restart.
        Reconnect,
        [ModelEnumValue("ROOMSTATE")]   // Identifies the channel’s chat settings (e.g., slow mode duration).
        RoomState,
        [ModelEnumValue("USERNOTICE")]  // Announces Twitch-specific events to the channel
        UserNotice,
        [ModelEnumValue("USERSTATE")]   // Identifies a user’s chat settings or properties
        UserState,
        [ModelEnumValue("CAP * ACK")]   // Response to a capability request
        CapabilityAck,

        // Outgoing Only
        [ModelEnumValue("PING")]        // Ping
        Ping,
        [ModelEnumValue("PASS")]        // Password part of auth
        Password,
        [ModelEnumValue("NICK")]        // Nickname part of auth
        Nickname,
        [ModelEnumValue("CAP REQ")]     // Request a capability from the server membership/tags/commands
        Capability,
        [ModelEnumValue("JOIN")]        // Join a channel.
        Join,
        [ModelEnumValue("PART")]        // Depart from a channel.
        Part
    }
}
