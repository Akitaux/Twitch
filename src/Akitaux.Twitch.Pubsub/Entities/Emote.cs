using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub.Entities
{
    public class Emote
    {
        [ModelProperty("id")]
        public ulong Id { get; set; }
        [ModelProperty("start")]
        public int Start { get; set; }
        [ModelProperty("end")]
        public int End { get; set; }
    }
}
