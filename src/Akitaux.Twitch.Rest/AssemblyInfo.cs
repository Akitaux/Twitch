using System.Runtime.CompilerServices;
using RestEase;

[assembly: InternalsVisibleTo(RestClient.FactoryAssemblyName)]
[assembly: InternalsVisibleTo("Akitaux.Twitch.Helix")]
[assembly: InternalsVisibleTo("Akitaux.Twitch.Kraken")]
[assembly: InternalsVisibleTo("Akitaux.Twitch.Authorization")]