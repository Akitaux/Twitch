using System.Collections.Generic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class ExtensionLocation
    {
        [ModelProperty("panel")]
        public Dictionary<int, Extension> Panel { get; set; }
        [ModelProperty("overlay")]
        public Dictionary<int, Extension> Overlay { get; set; }
        [ModelProperty("component")]
        public Dictionary<int, Extension> Component { get; set; }
    }
}
