using System.Collections.Generic;
using System.Linq;
using Voltaic;

namespace Akitaux.Twitch.Helix.Requests
{
    public class GetUsersParams : Rest.QueryMap
    {
        public static readonly string[] OptionalScopes = { "user:read:email" };

        public Optional<ulong[]> UserIds { get; set; }
        public Optional<Utf8String[]> UserNames { get; set; }

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            if (UserIds.IsSpecified)
                dict["user_id"] = UserIds.Value.Select(x => x.ToString());
            if (UserNames.IsSpecified)
                dict["login"] = UserNames.Value;
            return dict;
        }

        public void Validate()
        {
            if (UserIds.IsSpecified)
            {
                Preconditions.CountGreaterThan(UserIds, 100, nameof(UserIds));
                Preconditions.CountLessThan(UserIds, 1, nameof(UserIds));
            }
            if (UserNames.IsSpecified)
            {
                Preconditions.CountGreaterThan(UserNames, 100, nameof(UserIds));
                Preconditions.CountLessThan(UserNames, 1, nameof(UserIds));
            }
        }
    }
}
