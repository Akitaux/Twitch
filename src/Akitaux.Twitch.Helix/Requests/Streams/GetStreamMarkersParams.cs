using System;
using System.Collections.Generic;
using Voltaic;

namespace Akitaux.Twitch.Helix.Requests
{
    public class GetStreamMarkersParams : Rest.QueryMap
    {
        public static readonly string[] RequiredScopes = { "user:read:broadcast" };
        
        public Optional<ulong> UserId { get; set; }
        public Optional<ulong> VideoId { get; set; }
        public Optional<int> First { get; set; }
        public Optional<Utf8String> After { get; set; }
        public Optional<Utf8String> Before { get; set; }

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            if (UserId.IsSpecified)
                dict["user_id"] = UserId.Value;
            if (VideoId.IsSpecified)
                dict["video_id"] = VideoId.Value;
            if (First.IsSpecified)
                dict["first"] = First.Value;
            if (After.IsSpecified)
                dict["after"] = After.Value;
            if (Before.IsSpecified)
                dict["before"] = Before.Value;
            return dict;
        }

        public void Validate()
        {
            int specified = 0;
            if (UserId.IsSpecified)
            {
                specified++;
                Preconditions.NotZero(UserId, nameof(UserId));
            }
            if (VideoId.IsSpecified)
            {
                specified++;
                Preconditions.NotZero(VideoId, nameof(VideoId));
            }

            if (specified > 1)
                throw new ArgumentException($"Only one of {nameof(UserId)} or {nameof(VideoId)} can be specified for this request.");
            if (specified == 0)
                throw new ArgumentException($"Either {nameof(UserId)} or {nameof(VideoId)} must be specified for this request.");

            if (First.IsSpecified)
            {
                Preconditions.AtLeast(First, 1, nameof(First));
                Preconditions.AtMost(First, 100, nameof(First));
            }
            if (After.IsSpecified)
                Preconditions.NotNullOrWhitespace(After.ToString(), nameof(After));
            if (Before.IsSpecified)
                Preconditions.NotNullOrWhitespace(Before.ToString(), nameof(Before));
        }
    }
}
