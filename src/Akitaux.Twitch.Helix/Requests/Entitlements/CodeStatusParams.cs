using System.Collections.Generic;
using Voltaic;

namespace Akitaux.Twitch.Helix.Requests
{
    public class CodeStatusParams : Rest.QueryMap
    {
        public Utf8String[] Codes { get; set; }
        public ulong UserId { get; set; }

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            dict["code"] = Codes;
            dict["user_id"] = UserId;
            return dict;
        }

        public void Validate()
        {
            Preconditions.NotZero(UserId, nameof(UserId));
        }
    }
}
