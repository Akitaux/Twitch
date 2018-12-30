using Akitaux.Twitch.Helix.Entities;
using RestEase;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Akitaux.Twitch.Helix
{
    [Header("User-Agent", "Akitaux (https://github.com/Akitaux/Twitch)")]
    internal interface IHelixRestApi : IDisposable
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        // Analytics
        [Get("helix/analytics/extensions")]
        Task<TwitchResponse<ExtensionAnalyticReport>> GetExtensionAnalyticsAsync([QueryMap]GetExtensionAnalyticsParams args);
        [Get("helix/analytics/games")]
        Task<TwitchResponse<GameAnalyticReport>> GetGameAnalyticsAsync([QueryMap]GetGameAnalyticsParams args);

        // Bits
        [Get("helix/bits/leaderboard")]
        Task<TwitchResponse<BitsLeader>> GetBitsLeaderboardAsync([QueryMap]GetBitsLeaderboardParams args);

        // Clips

        // Entitlements

        // Games

        // Streams

        // Users

        // Videos
    }
}
