using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Identity.Entities
{
    public class TokenInfo
    {
        // Refresh
        [ModelProperty("access_token")]
        public Utf8String AccessToken { get; set; }
        [ModelProperty("refresh_token")]
        public Utf8String RefreshToken { get; set; }
        [ModelProperty("scope")]
        public Utf8String[] Scopes { get; set; }

        // Authorize
        [ModelProperty("expires_in")]
        public Optional<int> ExpiresIn { get; set; }
        [ModelProperty("token_type")]
        public Optional<Utf8String> TokenType { get; set; }
    }
}
