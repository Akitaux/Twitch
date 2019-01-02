using System;
using System.Collections.Generic;
using System.Xml;

namespace Akitaux.Twitch.Helix.Requests
{
    public class GetClipsParams : Rest.QueryMap
    {
        public Optional<string> Id { get; set; }
        public Optional<ulong> BroadcasterId { get; set; }
        public Optional<ulong> GameId { get; set; }

        public Optional<int> First { get; set; }
        public Optional<string> After { get; set; }
        public Optional<string> Before { get; set; }
        public Optional<DateTime> StartedAt { get; set; }
        public Optional<DateTime> EndedAt { get; set; }
        
        public override IDictionary<string, object> GetQueryMap()
        {
            var dict = new Dictionary<string, object>();
            if (Id.IsSpecified)
                dict["id"] = Id.Value;
            if (BroadcasterId.IsSpecified)
                dict["broadcaster_id"] = BroadcasterId.Value;
            if (GameId.IsSpecified)
                dict["game_id"] = GameId.Value;
            if (First.IsSpecified)
                dict["first"] = First.Value;
            if (After.IsSpecified)
                dict["after"] = After.Value;
            if (Before.IsSpecified)
                dict["before"] = Before.Value;
            if (StartedAt.IsSpecified)
                dict["started_at"] = XmlConvert.ToString(StartedAt.Value, XmlDateTimeSerializationMode.Utc);
            if (EndedAt.IsSpecified)
                dict["ended_at"] = XmlConvert.ToString(EndedAt.Value, XmlDateTimeSerializationMode.Utc);
            return dict;
        }

        public void Validate()
        {
            if (!Id.IsSpecified && !BroadcasterId.IsSpecified && !GameId.IsSpecified)
                throw new ArgumentException($"At least one of the listed parameters must have a value for this request: {nameof(Id)}, {nameof(BroadcasterId)}, or {nameof(GameId)}");

            if (Id.IsSpecified)
                Preconditions.NotNullOrWhitespace(Id, nameof(Id));
            if (First.IsSpecified)
            {
                Preconditions.AtLeast(First, 1, nameof(First));
                Preconditions.AtMost(First, 100, nameof(First));
            }
            if (Before.IsSpecified)
                Preconditions.NotNullOrWhitespace(Before, nameof(Before));
            if (Before.IsSpecified)
                Preconditions.NotNullOrWhitespace(Before, nameof(Before));
        }
    }
}
