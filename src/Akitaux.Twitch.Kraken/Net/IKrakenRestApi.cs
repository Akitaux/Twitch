using System;
using System.Net.Http.Headers;
using RestEase;
using Voltaic;

namespace Akitaux.Twitch.Kraken
{
    public interface IKrakenRestApi : IDisposable
    {
        [Header("Authorization")]
        AuthenticationHeaderValue Authorization { get; set; }
        [Header("Client-ID")]
        Utf8String ClientId { get; set; }
    }
}
