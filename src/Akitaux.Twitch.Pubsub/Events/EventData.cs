using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub.Events
{
    public class EventData<T> 
        where T : class
    {
        [ModelProperty("data")]
        public T Data { get; set; }

        [ModelProperty("version")]
        public Optional<Utf8String> Version { get; set; }
        [ModelProperty("message_type")]
        public Optional<Utf8String> MessageType { get; set; }
        [ModelProperty("message_id")]
        public Optional<Utf8String> MessageId { get; set; }
        [ModelProperty("is_anonymous")]
        public Optional<bool> IsAnonymous { get; set; }
    }
}
