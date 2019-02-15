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
        [Header("Client-ID")]
        NameValueHeaderValue ClientId { get; set; }

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
        [Get("entitlements/code")]
        Task<EntitlementsResponse<EntitlementCodeStatus>> GetCodeStatusAsync([QueryMap]CodeStatusParams args);
        [Post("entitlements/code")]
        Task<EntitlementsResponse<EntitlementCodeStatus>> RedeemCodeAsync([QueryMap]CodeStatusParams args);

        // Games
        [Get("games/top")]
        Task<TwitchResponse<Game>> GetTopGamesAsync([QueryMap]GetTopGamesParams args = null);
        [Get("games")]
        Task<TwitchResponse<Game>> GetGamesAsync([QueryMap]GetGamesParams args);

        // Streams
        [Get("streams")]
        Task<TwitchResponse<Stream>> GetStreamsAsync([QueryMap]GetStreamsParams args = null);
        //[Get("streams/metadata")]
        //Task<TwitchResponse<StreamMetadata>> GetStreamMetadatasAsync([QueryMap]GetStreamMetadatasParams args = null);
        [Post("streams/markers")]
        Task<TwitchResponse<StreamMarker>> CreateStreamMarkerAsync([Body]CreateStreamMarkerParams args);
        [Get("streams/markers")]
        Task<TwitchResponse<Stream>> GetStreamMarkersAsync([QueryMap]GetStreamMarkersParams args);

        // Subscriptions

        // Tags

        // Users

        // Videos

        // Webhooks

    }
}
