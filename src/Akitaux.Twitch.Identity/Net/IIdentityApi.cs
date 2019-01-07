using Akitaux.Twitch.Identity.Requests;
using RestEase;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Akitaux.Twitch.Identity.Net
{
    public interface IIdentityApi : IDisposable
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        [Get("oauth2/authorize")]
        Task<object> AuthorizeAsync([QueryMap]AuthorizationParams args);
        [Get("oauth2/validate")]
        Task<object> ValidateAsync();
        [Get("oauth2/revoke")]
        Task<object> RevokeTokenAsync(string clientId, string token);

        [Get("oauth2/userinfo")]
        Task<object> GetUserInfoAsync();
        [Get("oauth2/keys")]
        Task<object> GetKeysAsync();

        [Get("oauth2/.well-known/openid-configuration")]
        Task<object> GetOpenIdConfigurationAsync();
    }
}
