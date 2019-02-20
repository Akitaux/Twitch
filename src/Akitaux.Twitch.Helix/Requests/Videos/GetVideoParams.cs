using System;
using System.Collections.Generic;
using Akitaux.Twitch.Helix.Entities;
using Voltaic;

namespace Akitaux.Twitch.Helix.Requests
{
    public class GetVideoParams : Rest.QueryMap
    {
        public Optional<ulong[]> VideoIds { get; set; }
        public Optional<ulong> UserId { get; set; }
        public Optional<Utf8String> GameId { get; set; }
        
        public Optional<Utf8String> Language { get; set; }
        public Optional<VideoPeriod> Period { get; set; }
        public Optional<VideoSort> Sort { get; set; }
        public Optional<VideoType> Type { get; set; }

        public Optional<int> First { get; set; }
        public Optional<Utf8String> After { get; set; }
        public Optional<Utf8String> Before { get; set; }

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            if (VideoIds.IsSpecified)
                dict["id"] = VideoIds.Value;
            if (UserId.IsSpecified)
                dict["user_id"] = UserId.Value;
            if (GameId.IsSpecified)
                dict["game_id"] = GameId.Value;
            if (Language.IsSpecified)
                dict["language"] = Language.Value;
            if (Period.IsSpecified)
                dict["period"] = Period.Value;
            if (Sort.IsSpecified)
                dict["sort"] = Sort.Value;
            if (Type.IsSpecified)
                dict["type"] = Type.Value;
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
            if (!VideoIds.IsSpecified && !UserId.IsSpecified && !GameId.IsSpecified)
                throw new ArgumentException($"At least one of the following parameters must be specified: {nameof(VideoIds)}, {nameof(UserId)}, or {nameof(GameId)}");

            if (VideoIds.IsSpecified)
            {
                Preconditions.CountGreaterThan(VideoIds, 100, nameof(VideoIds));
                Preconditions.CountLessThan(VideoIds, 1, nameof(VideoIds));
            }
            
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
