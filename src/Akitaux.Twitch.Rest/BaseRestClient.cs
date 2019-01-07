using System;
using System.Reflection;

namespace Akitaux.Twitch.Rest
{
    public abstract class BaseRestClient : IDisposable
    {
        public static string Version { get; } =
            typeof(BaseRestClient).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ??
            typeof(BaseRestClient).GetTypeInfo().Assembly.GetName().Version.ToString(3) ??
            "Unknown";
        
        public TwitchJsonSerializer JsonSerializer { get; }
        
        public BaseRestClient(TwitchJsonSerializer serializer = null)
        {
            JsonSerializer = serializer ?? new TwitchJsonSerializer();
        }
        public virtual void Dispose() { }
    }
}
