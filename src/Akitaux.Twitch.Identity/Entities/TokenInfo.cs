using Voltaic;

namespace Akitaux.Twitch.Identity.Entities
{
    public class TokenInfo
    {
        public Optional<Utf8String> ClientId { get; set; }
        public Optional<Utf8String> Login { get; set; }
        public Optional<Utf8String[]> Scopes { get; set; }
        public Optional<ulong> UserId { get; set; }
    }
}
