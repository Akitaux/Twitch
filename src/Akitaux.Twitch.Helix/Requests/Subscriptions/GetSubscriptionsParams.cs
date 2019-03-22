using System.Collections.Generic;
using System.Linq;
using Voltaic;

namespace Akitaux.Twitch.Helix.Requests
{
    public class GetSubscriptionsParams : Rest.QueryMap
    {
        public static readonly string[] RequiredScopes = { "channel:read:subscriptions" };

        public ulong BroadcasterId { get; set; }
        public Optional<ulong[]> UserIds { get; set; }

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            dict["broadcaster_id"] = BroadcasterId;
            if (UserIds.IsSpecified)
                dict["user_id"] = UserIds.Value.Select(x => x.ToString());
            return dict;
        }

        public void Validate()
        {
            if (UserIds.IsSpecified)
            {
                Preconditions.CountGreaterThan(UserIds, 100, nameof(UserIds));
                Preconditions.CountLessThan(UserIds, 1, nameof(UserIds));
            }
        }
    }
}
