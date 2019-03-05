using System.Collections.Generic;
using Voltaic;

namespace Akitaux.Twitch.Helix.Requests
{
    public class CreateClipParams : Rest.QueryMap
    {
        public static readonly string[] RequiredScopes = { "clips:edit" };

        public ulong BroadcasterId { get; set; }
        public Optional<bool> HasDelay { get; set; }

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            dict["broadcaster_id"] = BroadcasterId.ToString();
            if (HasDelay.IsSpecified)
                dict["has_delay"] = HasDelay.ToString();
            return dict;
        }
    }
}
