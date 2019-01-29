using System;
using Akitaux.Twitch.Chat.Serialization;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Chat.Events
{
    public class MessageReceivedEvent
    {
        [ModelProperty("badges")]
        public string Badges { get; set; }
        [ModelProperty("color")]
        public string ColorHex { get; set; }
        [ModelProperty("display-name")]
        public string DisplayName { get; set; }
        [ModelProperty("emotes")]
        public string EmoteIndices { get; set; }
        [ModelProperty("flags")]
        public string Flags { get; set; }
        [ModelProperty("id")]
        public string Id { get; set; }
        [ModelProperty("mod")]
        public bool IsMod { get; set; }
        [ModelProperty("room-id")]
        public ulong RoomId { get; set; }
        [ModelProperty("subscriber")]
        public bool IsSubscriber { get; set; }
        [ModelProperty("tmi-sent-ts")]
        public DateTime TmiSentTimestamp { get; set; }
        [ModelProperty("turbo")]
        public bool IsTurbo { get; set; }
        [ModelProperty("user-id")]
        public ulong UserId { get; set; }
        [ModelProperty("user-type")]
        public string UserType { get; set; }

        [ModelParameterIndex(0)]
        public string ChannelName { get; set; }
        [ModelParameterIndex(1)]
        public string Content { get; set; }

    }
}
