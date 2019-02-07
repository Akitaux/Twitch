using System.Collections.Generic;

namespace Akitaux.Twitch.Identity.Requests
{
    public class RevokeParams : Rest.QueryMap
    {
        public string ClientId { get; set; }
        public string Token { get; set; }

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            dict["client_id"] = ClientId;
            dict["token"] = Token;
            return dict;
        }

        public void Validate()
        {
            Preconditions.NotNullOrWhitespace(ClientId, nameof(ClientId));
            Preconditions.NotNullOrWhitespace(Token, nameof(Token));
        }
    }
}
