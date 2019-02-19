using System.Collections.Generic;
using Voltaic;

namespace Akitaux.Twitch.Helix.Requests
{
    public class GetTagsParams : Rest.QueryMap
    {
        public Optional<Utf8String[]> TagIds { get; set; }
        public Optional<int> First { get; set; }
        public Optional<Utf8String> After { get; set; }

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            if (TagIds.IsSpecified)
                dict["tag_id"] = TagIds.Value;
            if (First.IsSpecified)
                dict["first"] = First.Value;
            if (After.IsSpecified)
                dict["after"] = After.Value;
            return dict;
        }

        public void Validate()
        {
            if (TagIds.IsSpecified)
            {
                Preconditions.CountGreaterThan(TagIds, 100, nameof(TagIds));
                Preconditions.CountLessThan(TagIds, 1, nameof(TagIds));
            }
            if (First.IsSpecified)
            {
                Preconditions.AtLeast(First, 1, nameof(First));
                Preconditions.AtMost(First, 100, nameof(First));
            }
            if (After.IsSpecified)
                Preconditions.NotNullOrWhitespace(After.ToString(), nameof(After));
        }
    }
}
