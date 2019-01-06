using System.Collections.Generic;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Requests
{
    public class GetStreamsParams : Rest.QueryMap
    {
        [ModelProperty("community_id")]
        public Optional<List<Utf8String>> CommunityIds { get; set; }
        [ModelProperty("game_id")]
        public Optional<List<Utf8String>> GameIds { get; set; }
        [ModelProperty("language")]
        public Optional<List<Utf8String>> Languages { get; set; }
        [ModelProperty("user_id")]
        public Optional<List<ulong>> UserIds { get; set; }
        [ModelProperty("user_login")]
        public Optional<List<Utf8String>> UserNames { get; set; }
        [ModelProperty("first")]
        public Optional<int> First { get; set; }
        [ModelProperty("after")]
        public Optional<Utf8String> After { get; set; }
        [ModelProperty("before")]
        public Optional<Utf8String> Before { get; set; }

        public override IDictionary<string, object> GetQueryMap()
        {
            var dict = new Dictionary<string, object>();
            if (CommunityIds.IsSpecified)
                dict["community_id"] = CommunityIds.Value;
            if (GameIds.IsSpecified)
                dict["game_id"] = GameIds.Value;
            if (Languages.IsSpecified)
                dict["language"] = Languages.Value;
            if (UserIds.IsSpecified)
                dict["user_id"] = UserIds.Value;
            if (UserNames.IsSpecified)
                dict["user_login"] = UserNames.Value;
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
            if (CommunityIds.IsSpecified)
            {
                Preconditions.CountGreaterThan(CommunityIds, 100, nameof(CommunityIds));
                Preconditions.CountLessThan(CommunityIds, 1, nameof(CommunityIds));
            }
            if (GameIds.IsSpecified)
            {
                Preconditions.CountGreaterThan(GameIds, 100, nameof(GameIds));
                Preconditions.CountLessThan(GameIds, 1, nameof(GameIds));
            }
            if (Languages.IsSpecified)
            {
                Preconditions.CountGreaterThan(Languages, 100, nameof(Languages));
                Preconditions.CountLessThan(Languages, 1, nameof(Languages));
            }
            if (UserIds.IsSpecified)
            {
                Preconditions.CountGreaterThan(UserIds, 100, nameof(UserIds));
                Preconditions.CountLessThan(UserIds, 1, nameof(UserIds));
            }
            if (UserNames.IsSpecified)
            {
                Preconditions.CountGreaterThan(UserNames, 100, nameof(UserNames));
                Preconditions.CountLessThan(UserNames, 1, nameof(UserNames));
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
