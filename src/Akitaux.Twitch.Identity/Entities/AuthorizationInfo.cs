using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Identity.Entities
{
    public class AuthorizationInfo
    {
        [ModelProperty("client_id")]
        public Utf8String ClientId { get; set; }
        [ModelProperty("login")]
        public Utf8String Login { get; set; }
        [ModelProperty("scopes")]
        public Utf8String[] Scopes { get; set; }
        [ModelProperty("user_id")]
        public ulong UserId { get; set; }
    }
}
