using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Akitaux.Twitch.Rest
{
    public class DefaultRateLimiter : IRateLimiter
    {
        private readonly ConcurrentDictionary<string, RequestBucket> _buckets;

        public DefaultRateLimiter()
        {
            _buckets = new ConcurrentDictionary<string, RequestBucket>();
        }

        public async Task EnterLockAsync(string bucketId, CancellationToken cancelToken)
        {
            await EnterGlobalLockAsync(cancelToken).ConfigureAwait(false);
            await EnterBucketLockAsync(bucketId, cancelToken).ConfigureAwait(false);
        }

        public virtual async Task EnterGlobalLockAsync(CancellationToken cancelToken)
        {
            while (true)
            {
                int millis = (int)Math.Ceiling(a: DateTimeOffset.UtcNow.Ticks);
                if (millis <= 0)
                    break;
                else
                    await Task.Delay(millis).ConfigureAwait(false);
            }
        }
        public virtual async Task EnterBucketLockAsync(string bucketId, CancellationToken cancelToken)
        {
            var bucket = _buckets.GetOrAdd(bucketId, x => new RequestBucket(this));
            await bucket.EnterAsync(cancelToken);
        }

        public virtual void UpdateLimit(string bucketId, RateLimitInfo info)
        {
            var bucket = _buckets.GetOrAdd(bucketId, x => new RequestBucket(this));
            bucket.UpdateRateLimit(info);
        }
    }
}
