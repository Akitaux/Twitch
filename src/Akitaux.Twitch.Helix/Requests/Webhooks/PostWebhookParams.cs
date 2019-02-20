using System;
using Akitaux.Twitch.Helix.Entities;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Requests
{
    public class PostWebhookParams
    {
        [ModelProperty("hub.callback")]
        public Optional<Utf8String> CallbackUrl { get; set; }
        [ModelProperty("hub.mode")]
        public Optional<WebhookMode> Mode { get; set; }
        [ModelProperty("hub.topic")]
        public Optional<Utf8String> Topic { get; set; }
        [ModelProperty("hub.lease_seconds")]
        public Optional<int> LeaseSeconds { get; set; }
        [ModelProperty("hub.secret")]
        public Optional<Utf8String> Secret { get; set; }
        
        public void Validate()
        {
            if (CallbackUrl.IsSpecified)
                Preconditions.NotEmpty(CallbackUrl.ToString(), nameof(CallbackUrl));
            if (Topic.IsSpecified)
                Preconditions.NotEmpty(Topic.ToString(), nameof(Topic));
            if (Secret.IsSpecified)
                Preconditions.NotEmpty(Secret.ToString(), nameof(Secret));
            if (!Mode.IsSpecified)
                throw new ArgumentException(nameof(Mode));

            if (LeaseSeconds.IsSpecified)
            {
                Preconditions.GreaterThan(LeaseSeconds, 0, nameof(LeaseSeconds));
                Preconditions.LessThan(LeaseSeconds, 864000, nameof(LeaseSeconds));
            }
        }
    }
}
