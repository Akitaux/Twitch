using System.Threading;
using System.Threading.Tasks;

namespace Akitaux.Twitch.Rest
{
    public interface IRateLimiter
    {
        Task EnterLockAsync(string bucketId, CancellationToken cancelToken);
        void UpdateLimit(string bucketId, RateLimitInfo info);
    }
}
