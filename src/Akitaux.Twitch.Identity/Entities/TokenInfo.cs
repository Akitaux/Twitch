using System.Collections.Generic;
using Voltaic;

namespace Akitaux.Twitch.Identity
{
    public class TokenInfo
    {
        public Optional<string> ClientId { get; set; }
        public Optional<string> Login { get; set; }
        public Optional<List<string>> Scopes { get; set; }
        public Optional<ulong> UserId { get; set; }
    }
}
