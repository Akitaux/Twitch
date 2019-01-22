using Voltaic.Serialization;

namespace Akitaux.Twitch.Chat.Requests
{
    public class IdentifyParams
    {
        [ModelProperty("PASS")]
        public string Password { get; set; }
        [ModelProperty("NICK")]
        public string Nickname { get; set; }
    }
}
