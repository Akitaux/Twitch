using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class Extension
    {
        [ModelProperty("id")]
        public Optional<Utf8String> Id { get; set; }
        [ModelProperty("version")]
        public Optional<Utf8String> Version { get; set; }
        [ModelProperty("name")]
        public Optional<Utf8String> Name { get; set; }
        [ModelProperty("type")]
        public Optional<Utf8String[]> Types { get; set; }
        [ModelProperty("can_activate")]
        public Optional<bool> CanActivate { get; set; }

        [ModelProperty("active")]
        public Optional<bool> IsActivate { get; set; }
        [ModelProperty("x")]
        public Optional<int> XCoord { get; set; }
        [ModelProperty("y")]
        public Optional<int> YCoord { get; set; }
    }
}
