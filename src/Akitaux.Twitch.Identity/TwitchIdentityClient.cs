using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Akitaux.Twitch.Identity.Entities;
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

        public Task<AuthorizationInfo> ValidateAsync()
        {
            return _api.ValidateAsync();
        }

        public Task AuthorizeAsync(AuthorizationParams args)
        {
            args.Validate();
            return _api.AuthorizeAsync(args);
        }

        public Task<TokenInfo> RefreshTokenAsync(RefreshParams args)
        {
            args.Validate();
            return _api.RefreshTokenAsync(args);
        }

        public Task RevokeTokenAsync(RevokeParams args)
        {
            args.Validate();
            return _api.RevokeTokenAsync(args);
        }
    }
}
