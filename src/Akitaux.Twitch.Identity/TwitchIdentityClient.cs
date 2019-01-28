using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Akitaux.Twitch.Identity.Net;
using Akitaux.Twitch.Identity.Requests;
using Akitaux.Twitch.Rest;
using RestEase;

namespace Akitaux.Twitch.Identity
{
    public class TwitchIdentityClient : BaseRestClient, IIdentityApi, IDisposable
    {
        private readonly IIdentityApi _api;

        public AuthenticationHeaderValue Authorization { get => _api.Authorization; set => _api.Authorization = value; }

        public TwitchIdentityClient(TwitchJsonSerializer serializer = null, IRateLimiter rateLimiter = null)
            : this("https://id.twitch.tv/", serializer) { }
        public TwitchIdentityClient(string url, TwitchJsonSerializer serializer = null, IRateLimiter rateLimiter = null)
            : base(serializer)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(url) };
            httpClient.DefaultRequestHeaders.Add("User-Agent", $"Akitaux/v{Version} (https://github.com/Akitaux/Twitch)");

            _api = RestClient.For<IIdentityApi>(new WumpusRequester(httpClient, JsonSerializer, rateLimiter));
        }
        public override void Dispose() => _api.Dispose();

        public Task<object> AuthorizeAsync([QueryMap] AuthorizationParams args)
        {
            throw new NotImplementedException();
        }

        public Task<object> ValidateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<object> RevokeTokenAsync(string clientId, string token)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetUserInfoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<object> GetKeysAsync()
        {
            throw new NotImplementedException();
        }

        public Task<object> GetOpenIdConfigurationAsync()
        {
            throw new NotImplementedException();
        }
    }
}
