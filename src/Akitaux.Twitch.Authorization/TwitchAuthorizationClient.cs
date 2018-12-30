using Akitaux.Twitch.Authorization.Net;
using Akitaux.Twitch.Rest;
using RestEase;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using Voltaic.Serialization.Json;

namespace Akitaux.Twitch.Authorization
{
    public class TwitchAuthorizationClient
    {
        public static string Version { get; } =
            typeof(TwitchAuthorizationClient).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ??
            typeof(TwitchAuthorizationClient).GetTypeInfo().Assembly.GetName().Version.ToString(3) ??
            "Unknown";

        private readonly IAuthorizationRestApi _api;

        public AuthenticationHeaderValue Authorization { get => _api.Authorization; set => _api.Authorization = value; }
        public JsonSerializer JsonSerializer { get; }

        public TwitchAuthorizationClient(JsonSerializer serializer = null, IRateLimiter rateLimiter = null)
            : this("https://id.twitch.tv/", serializer) { }
        public TwitchAuthorizationClient(string url, JsonSerializer serializer = null, IRateLimiter rateLimiter = null)
        {
            JsonSerializer = serializer ?? new JsonSerializer();
            rateLimiter = rateLimiter ?? new DefaultRateLimiter();

            var httpClient = new HttpClient { BaseAddress = new Uri(url) };
            httpClient.DefaultRequestHeaders.Add("User-Agent", $"Akitaux (https://github.com/Akitaux/Twitch), v{Version})");

            _api = RestClient.For<IAuthorizationRestApi>(new WumpusRequester(httpClient, JsonSerializer, rateLimiter));
        }
        public void Dispose() => _api.Dispose();

    }
}
