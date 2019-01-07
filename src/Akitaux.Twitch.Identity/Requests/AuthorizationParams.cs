using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Identity.Requests
{
    public class AuthorizationParams
    {
        [ModelProperty("client_id")]
        public Optional<Utf8String> ClientId { get; set; }
        [ModelProperty("redirect_uri")]
        public Optional<Utf8String> RedirectUri { get; set; }
        [ModelProperty("response_type")]
        public Optional<Utf8String> ResponseType { get; set; }
        [ModelProperty("scopes")]
        public Optional<Utf8String[]> Scopes { get; set; }
        [ModelProperty("claims")]
        public Optional<Utf8String> Claims { get; set; }
        [ModelProperty("nonce")]
        public Optional<Utf8String> Nonce { get; set; }
        [ModelProperty("state")]
        public Optional<Utf8String> State { get; set; }
    }
}
