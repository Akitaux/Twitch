using Akitaux.Twitch.Identity.Entities;
using Akitaux.Twitch.Identity.Requests;
using RestEase;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Akitaux.Twitch.Identity
{
    public interface IIdentityApi : IDisposable
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }

        [Get("oauth2/validate")]
        Task<AuthorizationInfo> ValidateAsync();
        [Get("oauth2/authorize")]
        Task AuthorizeAsync([QueryMap]AuthorizationParams args);
        [Post("oauth2/token")]
        Task<TokenInfo> RefreshTokenAsync([QueryMap]RefreshParams args);
        [Get("oauth2/revoke")]
        Task RevokeTokenAsync([QueryMap]RevokeParams args);

        //[Get("oauth2/userinfo")]
        //Task<object> GetUserInfoAsync();
        //[Get("oauth2/keys")]
        //Task<object> GetKeysAsync();

        //[Get("oauth2/.well-known/openid-configuration")]
        //Task<object> GetOpenIdConfigurationAsync();
    }
}
