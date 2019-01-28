using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Akitaux.Twitch.Rest;
using RestEase;

namespace Akitaux.Twitch.Kraken
{
    public class TwitchKrakenClient : BaseRestClient, IKrakenRestApi, IDisposable
    {
        private readonly IKrakenRestApi _api;

        public AuthenticationHeaderValue Authorization { get => _api.Authorization; set => _api.Authorization = value; }
        public NameValueHeaderValue ClientId { get => _api.ClientId; set => _api.ClientId = value; }

        public TwitchKrakenClient(TwitchJsonSerializer serializer = null, IRateLimiter rateLimiter = null)
            : this("https://api.twitch.tv/kraken", serializer, rateLimiter) { }
        public TwitchKrakenClient(string url, TwitchJsonSerializer serializer = null, IRateLimiter rateLimiter = null)
            : base(serializer)
        {
            rateLimiter = rateLimiter ?? new DefaultRateLimiter();

            var httpClient = new HttpClient { BaseAddress = new Uri(url) };
            httpClient.DefaultRequestHeaders.Add("User-Agent", $"Akitaux/v{Version} (https://github.com/Akitaux/Twitch)");

            _api = RestClient.For<IKrakenRestApi>(new WumpusRequester(httpClient, JsonSerializer, rateLimiter));
        }
        public override void Dispose() => _api.Dispose();
    }
}
