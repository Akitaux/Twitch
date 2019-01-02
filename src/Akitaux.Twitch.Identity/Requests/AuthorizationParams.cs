using System.Collections.Generic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Identity.Requests
{
    public class AuthorizationParams
    {
        [ModelProperty("client_id")]
        public Optional<string> ClientId { get; set; }
        [ModelProperty("redirect_uri")]
        public Optional<string> RedirectUri { get; set; }
        [ModelProperty("response_type")]
        public Optional<string> ResponseType { get; set; }
        [ModelProperty("scopes")]
        public Optional<List<string>> Scopes { get; set; }
        [ModelProperty("claims")]
        public Optional<string> Claims { get; set; }
        [ModelProperty("nonce")]
        public Optional<string> Nonce { get; set; }
        [ModelProperty("state")]
        public Optional<string> State { get; set; }
    }
}
