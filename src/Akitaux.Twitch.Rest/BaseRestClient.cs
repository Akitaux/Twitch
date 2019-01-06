using System;
using System.Reflection;
using Voltaic.Serialization.Json;

namespace Akitaux.Twitch.Rest
{
    public abstract class BaseRestClient : IDisposable
    {
        public static string Version { get; } =
            typeof(BaseRestClient).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ??
            typeof(BaseRestClient).GetTypeInfo().Assembly.GetName().Version.ToString(3) ??
            "Unknown";
        
        public JsonSerializer JsonSerializer { get; }
        
        public BaseRestClient(JsonSerializer serializer = null)
        {
            JsonSerializer = serializer ?? new JsonSerializer();
        }
        public virtual void Dispose() { }
    }
}
