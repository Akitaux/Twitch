using System;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class WebhookSubscription
    {
        [ModelProperty("topic")]
        public Optional<Utf8String> Topic { get; set; }
        [ModelProperty("callback")]
        public Optional<Utf8String> CallbackUrl { get; set; }
        [ModelProperty("expires_at")]
        public Optional<DateTime> ExpiresAt { get; set; }
    }
}
