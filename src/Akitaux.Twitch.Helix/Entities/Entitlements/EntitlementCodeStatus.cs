using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class EntitlementCodeStatus
    {
        [ModelProperty("code")]
        public Utf8String Code { get; set; }
        [ModelProperty("status")]
        public Utf8String Status { get; set; }
    }
}
