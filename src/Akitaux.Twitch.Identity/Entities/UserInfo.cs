using System;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Identity.Entities
{
    public class UserInfo
    {
        [ModelProperty("aud")]
        public Optional<Utf8String> Audience { get; set; }
        [ModelProperty("azp")]
        public Optional<Utf8String> AuthorizeParty { get; set; }
        [ModelProperty("exp")]
        public Optional<DateTime> ExpiresAt { get; set; }
        [ModelProperty("iat")]
        public Optional<DateTime> UsedAt { get; set; }
        [ModelProperty("iss")]
        public Optional<Utf8String> Issuer { get; set; }
        [ModelProperty("sub")]
        public Optional<ulong> UserId { get; set; }
    }
}
