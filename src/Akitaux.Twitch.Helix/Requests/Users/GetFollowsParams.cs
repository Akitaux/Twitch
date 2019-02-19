using System;
using System.Collections.Generic;
using Voltaic;

namespace Akitaux.Twitch.Helix.Requests
{
    public class GetFollowsParams : Rest.QueryMap
    {
        public Optional<ulong> FromId { get; set; }
        public Optional<ulong> ToId { get; set; }
        public Optional<int> First { get; set; }
        public Optional<Utf8String> After { get; set; }

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            if (FromId.IsSpecified)
                dict["from_id"] = FromId.Value;
            if (ToId.IsSpecified)
                dict["to_id"] = ToId.Value;
            if (First.IsSpecified)
                dict["first"] = First.Value;
            if (After.IsSpecified)
                dict["after"] = After.Value;
            return dict;
        }

        public void Validate()
        {
            if (!FromId.IsSpecified && !ToId.IsSpecified)
                throw new ArgumentException($"At least one of the following parameters must be specified: {nameof(FromId)} or {nameof(ToId)}");

            if (First.IsSpecified)
            {
                Preconditions.AtLeast(First, 20, nameof(First));
                Preconditions.AtMost(First, 100, nameof(First));
            }
            if (After.IsSpecified)
                Preconditions.NotNullOrWhitespace(After.ToString(), nameof(After));
        }
    }
}
