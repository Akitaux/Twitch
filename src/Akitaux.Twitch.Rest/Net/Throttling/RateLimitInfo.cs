using System;
using System.Linq;
using System.Net.Http.Headers;

namespace Akitaux.Twitch.Rest
{
    public struct RateLimitInfo
    {
        public int? Limit { get; }
        public int? Remaining { get; }
        public DateTimeOffset? Reset { get; }
        public TimeSpan? Lag { get; }

        internal RateLimitInfo(HttpResponseHeaders headers)
        {
            Limit = headers.TryGetValues("X-RateLimit-Limit", out var values) &&
                int.TryParse(values.First(), out var limit) ? limit : (int?)null;
            Remaining = headers.TryGetValues("X-RateLimit-Remaining", out values) &&
                int.TryParse(values.First(), out var remaining) ? remaining : (int?)null;
            Reset = headers.TryGetValues("X-RateLimit-Reset", out values) &&
                int.TryParse(values.First(), out var reset) ? DateTimeOffset.FromUnixTimeSeconds(reset) : (DateTimeOffset?)null;
            Lag = headers.TryGetValues("Date", out values) &&
                DateTimeOffset.TryParse(values.First(), out var date) ? DateTimeOffset.UtcNow - date : (TimeSpan?)null;
        }
    }
}
