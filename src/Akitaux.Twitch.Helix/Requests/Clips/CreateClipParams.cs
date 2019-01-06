using System.Collections.Generic;
using Voltaic;

namespace Akitaux.Twitch.Helix.Requests
{
    public class CreateClipParams : Rest.QueryMap
    {
        public const string RequiredScope = "bits:read";

        public ulong BroadcasterId { get; set; }
        public Optional<bool> HasDelay { get; set; }

        public override IDictionary<string, object> GetQueryMap()
        {
            var dict = new Dictionary<string, object>();
            dict["broadcaster_id"] = BroadcasterId.ToString();
            if (HasDelay.IsSpecified)
                dict["has_delay"] = HasDelay.ToString();
            return dict;
        }
    }
}
