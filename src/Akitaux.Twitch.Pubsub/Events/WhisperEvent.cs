using System;
using Akitaux.Twitch.Pubsub.Entities;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub.Events
{
    public class WhisperEvent
    {
        [ModelProperty("thread_id")]
        public Utf8String ThreadId { get; set; }
        [ModelProperty("body")]
        public Utf8String Body { get; set; }
        [ModelProperty("sent_ts")]
        public DateTime SentTimestamp { get; set; }
        [ModelProperty("from_id")]
        public ulong FromId { get; set; }
        [ModelProperty("tags")]
        public WhisperTags Tags { get; set; }
        [ModelProperty("recipient")]
        public User Recipient { get; set; }
        [ModelProperty("nonce")]
        public Utf8String Nonce { get; set; }
    }
}
