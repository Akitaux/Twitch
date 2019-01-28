using System;
using System.Net.Http.Headers;
using RestEase;

namespace Akitaux.Twitch.Kraken
{
    public interface IKrakenRestApi : IDisposable
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }
        [Header("Client-ID")]
        NameValueHeaderValue ClientId { get; set; }
    }
}
