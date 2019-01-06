using System;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Identity.Entities
{
    public class UserInfo
    {
        [ModelProperty("aud")]
        public Optional<string> Audience { get; set; }
        [ModelProperty("azp")]
        public Optional<string> AuthorizeParty { get; set; }
        [ModelProperty("exp")]
        public Optional<DateTime> ExpiresAt { get; set; }
        [ModelProperty("iat")]
        public Optional<DateTime> UsedAt { get; set; }
        [ModelProperty("iss")]
        public Optional<string> Issuer { get; set; }
        [ModelProperty("sub")]
        public Optional<ulong> UserId { get; set; }
    }
}
