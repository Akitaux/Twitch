using Akitaux.Twitch.Helix.Entities;
using Akitaux.Twitch.Rest;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Akitaux.Twitch.Helix
{
    public class GetGameAnalyticsParams : QueryMap
    {
        public const string RequiredScope = "analytics:read:games";

        public Optional<int> First { get; set; }
        public Optional<string> After { get; set; }
        public Optional<string> GameId { get; set; }
        public Optional<AnalyticType> Type { get; set; }
        public Optional<DateTime> StartedAt { get; set; }
        public Optional<DateTime> EndedAt { get; set; }

        public override IDictionary<string, object> GetQueryMap()
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
                Preconditions.NotNullOrWhitespace(After, nameof(After));
            if (GameId.IsSpecified)
                Preconditions.NotNullOrWhitespace(GameId, nameof(GameId));
            if (Type.IsSpecified)
                Preconditions.NotNullOrWhitespace(Type.ToString(), nameof(Type));
        }
    }
}
