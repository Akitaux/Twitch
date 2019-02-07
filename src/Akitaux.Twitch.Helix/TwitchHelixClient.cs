using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Akitaux.Twitch.Helix.Entities;
using Akitaux.Twitch.Helix.Requests;
using Akitaux.Twitch.Rest;
using RestEase;

namespace Akitaux.Twitch.Helix
{
    public class TwitchHelixClient : BaseRestClient, IHelixRestApi, IDisposable
    {
        private readonly IHelixRestApi _api;
        
        public AuthenticationHeaderValue Authorization { get => _api.Authorization; set => _api.Authorization = value; }
        public NameValueHeaderValue ClientId { get => _api.ClientId; set => _api.ClientId = value; }

        public TwitchHelixClient(TwitchJsonSerializer serializer = null, IRateLimiter rateLimiter = null)
            : this("https://api.twitch.tv/helix", serializer, rateLimiter) { }
        public TwitchHelixClient(string url, TwitchJsonSerializer serializer = null, IRateLimiter rateLimiter = null)
            : base(serializer)
        {
            rateLimiter = rateLimiter ?? new DefaultRateLimiter();

            var httpClient = new HttpClient { BaseAddress = new Uri(url) };
            httpClient.DefaultRequestHeaders.Add("User-Agent", $"Akitaux/v{Version} (https://github.com/Akitaux/Twitch)");

            _api = RestClient.For<IHelixRestApi>(new WumpusRequester(httpClient, JsonSerializer, rateLimiter));
        }
        public override void Dispose() => _api.Dispose();
        
        //  Analytics

        public Task<TwitchResponse<ExtensionAnalyticReport>> GetExtensionAnalyticsAsync(GetExtensionAnalyticsParams args)
        {
            args.Validate();
            return _api.GetExtensionAnalyticsAsync(args);
        }
        public Task<TwitchResponse<GameAnalyticReport>> GetGameAnalyticsAsync(GetGameAnalyticsParams args)
        {
            args.Validate();
            return _api.GetGameAnalyticsAsync(args);
        }
        
        // Bits

        public Task<TwitchResponse<BitsLeader>> GetBitsLeaderboardAsync(GetBitsLeaderboardParams args)
        {
            args.Validate();
            return _api.GetBitsLeaderboardAsync(args);
        }

        // Clips

        public Task<TwitchResponse<Clip>> CreateClipAsync(CreateClipParams args)
        {
            return _api.CreateClipAsync(args);
        }
        public Task<TwitchResponse<Clip>> GetClipsAsync(GetClipsParams args)
        {
            args.Validate();
            return _api.GetClipsAsync(args);
        }

        // Entitlements

        public Task<TwitchResponse<GrantsUploadUrl>> CreateGrantsUploadUrlAsync(CreateGrantsUploadUrlParams args)
        {
            args.Validate();
            return _api.CreateGrantsUploadUrlAsync(args);
        }

        public Task<EntitlementsResponse<EntitlementCodeStatus>> GetCodeStatusAsync(CodeStatusParams args)
        {
            args.Validate();
            return _api.GetCodeStatusAsync(args);
        }

        public Task<EntitlementsResponse<EntitlementCodeStatus>> RedeemCodeAsync(CodeStatusParams args)
        {
            args.Validate();
            return _api.RedeemCodeAsync(args);
        }
        
        // Games

        public Task<TwitchResponse<Game>> GetTopGamesAsync(GetTopGamesParams args = null)
        {
            args?.Validate();
            return _api.GetTopGamesAsync(args);
        }
        public Task<TwitchResponse<Game>> GetGamesAsync(GetGamesParams args)
        {
            args.Validate();
            return _api.GetGamesAsync(args);
        }

        // Streams

        public Task<TwitchResponse<Stream>> GetStreamsAsync(GetStreamsParams args = null)
        {
            args?.Validate();
            return _api.GetStreamsAsync(args);
        }

        // Users

        // Videos



    }
}
