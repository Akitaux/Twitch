using System.Collections.Generic;
using Voltaic;

namespace Akitaux.Twitch.Identity.Requests
{
    public class AuthorizationParams : Rest.QueryMap
    {
        public Utf8String ClientId { get; set; }
        public Utf8String RedirectUri { get; set; }
        public Utf8String ResponseType { get; } = new Utf8String("token");
        public string[] Scopes { get; set; }
        public Optional<bool> ForceVerify { get; set; }
        public Optional<Utf8String> State { get; set; }

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            dict["client_id"] = ClientId;
            dict["redirect_uri"] = RedirectUri;
            dict["response_type"] = ResponseType;
            dict["scope"] = string.Join("+", Scopes);
            if (ForceVerify.IsSpecified && ForceVerify.Value == true)
                dict["force_verify"] = "true";
            if (State.IsSpecified)
                dict["state"] = State.Value;
            return dict;
        }

        public void Validate()
        {
            Preconditions.NotNullOrWhitespace(ClientId.ToString(), nameof(ClientId));
            Preconditions.NotNullOrWhitespace(RedirectUri.ToString(), nameof(RedirectUri));

            if (State.IsSpecified)
                Preconditions.NotNullOrWhitespace(State.ToString(), nameof(State));
        }
    }
}
