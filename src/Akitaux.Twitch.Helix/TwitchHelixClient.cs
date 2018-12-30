using Akitaux.Twitch.Helix.Entities;
using Akitaux.Twitch.Rest;
using RestEase;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Voltaic.Serialization.Json;

namespace Akitaux.Twitch.Helix
{
    public class TwitchHelixClient : IHelixRestApi, IDisposable
    {
        public static string Version { get; } =
            typeof(TwitchHelixClient).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ??
            typeof(TwitchHelixClient).GetTypeInfo().Assembly.GetName().Version.ToString(3) ??
            "Unknown";

        private readonly IHelixRestApi _api;

        public AuthenticationHeaderValue Authorization { get => _api.Authorization; set => _api.Authorization = value; }
        public JsonSerializer JsonSerializer { get; }

        public TwitchHelixClient(JsonSerializer serializer = null, IRateLimiter rateLimiter = null)
            : this("https://api.twitch.tv/", serializer) { }
        public TwitchHelixClient(string url, JsonSerializer serializer = null, IRateLimiter rateLimiter = null)
        {
            JsonSerializer = serializer ?? new JsonSerializer();
            rateLimiter = rateLimiter ?? new DefaultRateLimiter();

            var httpClient = new HttpClient { BaseAddress = new Uri(url) };
            httpClient.DefaultRequestHeaders.Add("User-Agent", $"Akitaux (https://github.com/Akitaux/Twitch), v{Version})");

            _api = RestClient.For<IHelixRestApi>(new WumpusRequester(httpClient, JsonSerializer, rateLimiter));
        }
        public void Dispose() => _api.Dispose();
        
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
    }
}
