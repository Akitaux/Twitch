using System.Collections.Generic;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class Tag
    {
        [ModelProperty("tag_id")]
        public Utf8String Id { get; set; }
        [ModelProperty("localization_names")]
        public Dictionary<string, Utf8String> Names { get; set; }
        [ModelProperty("localization_descriptions")]
        public Dictionary<string, Utf8String> Descriptions { get; set; }
        [ModelProperty("is_auto")]
        public bool IsAuto { get; set; }
    }
}
