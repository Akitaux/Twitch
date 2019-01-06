using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Akitaux.Twitch.Helix.Entities;
using Akitaux.Twitch.Helix.Requests;
using RestEase;

namespace Akitaux.Twitch.Helix
{
    internal interface IHelixRestApi : IDisposable
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        // Analytics
        [Get("analytics/extensions")]
        Task<TwitchResponse<ExtensionAnalyticReport>> GetExtensionAnalyticsAsync([QueryMap]GetExtensionAnalyticsParams args);
        [Get("analytics/games")]
        Task<TwitchResponse<GameAnalyticReport>> GetGameAnalyticsAsync([QueryMap]GetGameAnalyticsParams args);

        // Bits
        [Get("bits/leaderboard")]
        Task<TwitchResponse<BitsLeader>> GetBitsLeaderboardAsync([QueryMap]GetBitsLeaderboardParams args);

        // Clips
        [Post("clips")]
        Task<TwitchResponse<Clip>> CreateClipAsync([QueryMap]CreateClipParams args);
        [Get("clips")]
        Task<TwitchResponse<Clip>> GetClipsAsync([QueryMap]GetClipsParams args);

        // Entitlements

        // Games

        // Streams
        [Get("streams")]
        Task<TwitchResponse<Stream>> GetStreamsAsync([QueryMap]GetStreamsParams args = null);

        // Users

        // Videos
    }
}
