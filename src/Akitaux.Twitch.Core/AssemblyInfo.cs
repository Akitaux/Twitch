using RestEase;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(RestClient.FactoryAssemblyName)]
[assembly: InternalsVisibleTo("Akitaux.Twitch.Rest")]
[assembly: InternalsVisibleTo("Akitaux.Twitch.Helix")]
[assembly: InternalsVisibleTo("Akitaux.Twitch.Kraken")]
[assembly: InternalsVisibleTo("Akitaux.Twitch.Identity")]
[assembly: InternalsVisibleTo("Akitaux.Twitch.Chat")]