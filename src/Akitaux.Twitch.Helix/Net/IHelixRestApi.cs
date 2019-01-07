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
        [Get("entitlements/upload")]
        Task<TwitchResponse<GrantsUploadUrl>> CreateGrantsUploadUrlAsync([QueryMap]CreateGrantsUploadUrlParams args);
        // Todo, they changed the response structure for these two requests for absolutely no reason
        //[Get("entitlements/code")]
        //Task<TwitchResponse<object>> GetCodeStatusAsync([QueryMap]object args = null);
        //[Post("entitlements/code")]
        //Task<TwitchResponse<object>> GetCodeStatusAsync([QueryMap]object args = null);

        // Games
        [Get("games/top")]
        Task<TwitchResponse<Game>> GetTopGamesAsync([QueryMap]GetTopGamesParams args = null);
        [Get("games")]
        Task<TwitchResponse<Game>> GetGamesAsync([QueryMap]GetGamesParams args);

        // Streams
        [Get("streams")]
        Task<TwitchResponse<Stream>> GetStreamsAsync([QueryMap]GetStreamsParams args = null);

        // Users

        // Videos
    }
}
