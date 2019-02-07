using Akitaux.Twitch.Helix.Entities;
using Akitaux.Twitch.Rest;
using System;
using System.Collections.Generic;
using System.Xml;
using Voltaic;

namespace Akitaux.Twitch.Helix.Requests
{
    public class GetExtensionAnalyticsParams : QueryMap
    {
        public static readonly string[] RequiredScopes = { "analytics:read:extensions" };

        public Optional<int> First { get; set; }
        public Optional<Utf8String> After { get; set; }
        public Optional<Utf8String> ExtensionId { get; set; }
        public Optional<DateTime> StartedAt { get; set; }
        public Optional<DateTime> EndedAt { get; set; }
        public Optional<AnalyticType> Type { get; set; }

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            if (First.IsSpecified)
                dict["first"] = First;
            if (After.IsSpecified)
                dict["after"] = After;
            if (ExtensionId.IsSpecified)
                dict["extension_id"] = ExtensionId;
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
            if (ExtensionId.IsSpecified)
                Preconditions.NotNullOrWhitespace(ExtensionId.ToString(), nameof(ExtensionId));
            if (Type.IsSpecified)
                Preconditions.NotNullOrWhitespace(Type.ToString(), nameof(Type));
        }
    }
}
