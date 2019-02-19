using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using Akitaux.Twitch.Rest;
using RestEase;

namespace Akitaux.Twitch.Kraken
{
    public class TwitchKrakenClient : IKrakenRestApi, IDisposable
    {
        public static string Version { get; } =
            typeof(TwitchKrakenClient).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ??
            typeof(TwitchKrakenClient).GetTypeInfo().Assembly.GetName().Version.ToString(3) ??
            "Unknown";

        private readonly IKrakenRestApi _api;

        public AuthenticationHeaderValue Authorization { get => _api.Authorization; set => _api.Authorization = value; }
        public NameValueHeaderValue ClientId { get => _api.ClientId; set => _api.ClientId = value; }

        public TwitchJsonSerializer JsonSerializer { get; }

        public TwitchKrakenClient(TwitchJsonSerializer serializer = null, IRateLimiter rateLimiter = null)
            : this("https://api.twitch.tv/kraken", serializer, rateLimiter) { }
        public TwitchKrakenClient(string url, TwitchJsonSerializer serializer = null, IRateLimiter rateLimiter = null)
        {
            JsonSerializer = serializer ?? new TwitchJsonSerializer();
            rateLimiter = rateLimiter ?? new DefaultRateLimiter();

            var httpClient = new HttpClient { BaseAddress = new Uri(url) };
            httpClient.DefaultRequestHeaders.Add("User-Agent", $"Akitaux/v{Version} (https://github.com/Akitaux/Twitch)");

            _api = RestClient.For<IKrakenRestApi>(new WumpusRequester(httpClient, JsonSerializer, rateLimiter));
        }
        public virtual void Dispose() => _api.Dispose();
    }
}
