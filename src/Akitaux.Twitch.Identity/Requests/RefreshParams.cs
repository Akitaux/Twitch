using System.Collections.Generic;

namespace Akitaux.Twitch.Identity
{
    public class RefreshParams : Rest.QueryMap
    {
        public string GrantType { get; } = "refresh_token";
        public string RefreshToken { get; set; }
        public string ClientSecret { get; set; }
        public string ClientId { get; set; }

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            dict["grant_type"] = GrantType;
            dict["refresh_token"] = RefreshToken;
            dict["client_secret"] = ClientSecret;
            dict["client_id"] = ClientId;
            return dict;
        }

        public void Validate()
        {
            Preconditions.NotNullOrWhitespace(RefreshToken, nameof(RefreshToken));
            Preconditions.NotNullOrWhitespace(ClientSecret, nameof(ClientSecret));
            Preconditions.NotNullOrWhitespace(ClientId, nameof(ClientId));
        }
    }
}
