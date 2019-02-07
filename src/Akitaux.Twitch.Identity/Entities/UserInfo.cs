using System;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Identity.Entities
{
    public class UserInfo
    {
        [ModelProperty("aud")]
        public Utf8String Audience { get; set; }
        [ModelProperty("azp")]
        public Utf8String AuthorizeParty { get; set; }
        [ModelProperty("exp")]
        public DateTime ExpiresAt { get; set; }
        [ModelProperty("iat")]
        public DateTime UsedAt { get; set; }
        [ModelProperty("iss")]
        public Utf8String Issuer { get; set; }
        [ModelProperty("sub")]
        public ulong UserId { get; set; }
        [ModelProperty("picture")]
        public Utf8String AvatarUrl { get; set; }
    }
}
