using System;
using System.Collections.Generic;
using System.Xml;
using Akitaux.Twitch.Helix.Entities;
using Voltaic;

namespace Akitaux.Twitch.Helix.Requests
{
    public class GetBitsLeaderboardParams : Rest.QueryMap
    {
        public static readonly string[] RequiredScopes = { "bits:read" };

        public Optional<int> Count { get; set; }
        public Optional<BitsPeriod> Period { get; set; }
        public Optional<DateTime> StartedAt { get; set; }
        public Optional<ulong> UserId { get; set; }

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            if (Count.IsSpecified)
                dict["count"] = Count.ToString();
            if (Period.IsSpecified)
                dict["period"] = Period.ToString();
            if (StartedAt.IsSpecified)
                dict["started_at"] = XmlConvert.ToString(StartedAt.Value, XmlDateTimeSerializationMode.Utc);
            if (UserId.IsSpecified)
                dict["user_id"] = UserId.ToString();
            return dict;
        }

        public void Validate()
        {
            if (Count.IsSpecified)
            {
                Preconditions.AtLeast(Count, 1, nameof(Count));
                Preconditions.AtMost(Count, 100, nameof(Count));
            }
        }
    }
}
