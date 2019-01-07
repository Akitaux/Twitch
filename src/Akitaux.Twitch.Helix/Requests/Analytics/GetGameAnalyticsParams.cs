using System;
using System.Collections.Generic;
using System.Xml;
using Akitaux.Twitch.Helix.Entities;
using Voltaic;

namespace Akitaux.Twitch.Helix.Requests
{
    public class GetGameAnalyticsParams : Rest.QueryMap
    {
        public const string RequiredScope = "analytics:read:games";

        public Optional<int> First { get; set; }
        public Optional<Utf8String> After { get; set; }
        public Optional<Utf8String> GameId { get; set; }
        public Optional<AnalyticType> Type { get; set; }
        public Optional<DateTime> StartedAt { get; set; }
        public Optional<DateTime> EndedAt { get; set; }

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            if (First.IsSpecified)
                dict["first"] = First.ToString();
            if (After.IsSpecified)
                dict["after"] = After.ToString();
            if (GameId.IsSpecified)
                dict["game_id"] = GameId.ToString();
            if (StartedAt.IsSpecified)
                dict["started_at"] = XmlConvert.ToString(StartedAt.Value, XmlDateTimeSerializationMode.Utc);
            if (EndedAt.IsSpecified)
                dict["ended_at"] = XmlConvert.ToString(EndedAt.Value, XmlDateTimeSerializationMode.Utc);
            if (Type.IsSpecified)
                dict["type"] = Type.ToString();
            return dict;
        }

        public void Validate()
        {
            if (First.IsSpecified)
            {
                Preconditions.AtLeast(First, 1, nameof(First));
                Preconditions.AtMost(First, 100, nameof(First));
            }
            if (After.IsSpecified)
                Preconditions.NotNullOrWhitespace(After.ToString(), nameof(After));
            if (GameId.IsSpecified)
                Preconditions.NotNullOrWhitespace(GameId.ToString(), nameof(GameId));
            if (Type.IsSpecified)
                Preconditions.NotNullOrWhitespace(Type.ToString(), nameof(Type));
        }
    }
}
