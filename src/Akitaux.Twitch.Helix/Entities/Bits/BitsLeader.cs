using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class BitsLeader
    {
        [ModelProperty("user_id")]
        public ulong Id { get; set; }
        [ModelProperty("user_name")]
        public Utf8String Username { get; set; }
        [ModelProperty("rank")]
        public int Rank { get; set; }
        [ModelProperty("score")]
        public int Score { get; set; }
    }
}
