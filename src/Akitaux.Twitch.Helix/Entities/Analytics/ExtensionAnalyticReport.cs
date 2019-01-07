using Akitaux.Twitch.Rest.Entities;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class ExtensionAnalyticReport
    {
        [ModelProperty("extension_id")]
        public Utf8String ExtensionId { get; set; }
        [ModelProperty("URL")]
        public Utf8String Url { get; set; }
        [ModelProperty("type")]
        public AnalyticType Type { get; set; }
        [ModelProperty("date_range")]
        public DateRange DateRange { get; set; }
    }
}
