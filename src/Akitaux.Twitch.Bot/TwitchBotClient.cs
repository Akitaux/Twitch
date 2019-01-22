using System.Net.Http.Headers;
using Akitaux.Twitch.Chat;
using Akitaux.Twitch.Helix;
using Akitaux.Twitch.Identity;
using Akitaux.Twitch.Kraken;

namespace Akitaux.Twitch.Bot
{
    public class TwitchBotClient
    {
        // Rest
        public TwitchHelixClient Helix { get; }
        public TwitchIdentityClient Identity { get; }
        public TwitchKrakenClient Kraken { get; set; }

        // WebSocket
        public TwitchChatClient Chat { get; set; }
        //public TwitchPubsubClient Pubsub { get; set; }
    }
}
