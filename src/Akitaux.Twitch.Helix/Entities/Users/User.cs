using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public class User
    {
        [ModelProperty("id")]
        public Optional<ulong> Id { get; set; }
        [ModelProperty("login")]
        public Optional<Utf8String> Name { get; set; }
        [ModelProperty("display_name")]
        public Optional<Utf8String> DisplayName { get; set; }
        [ModelProperty("type")]
        public Optional<UserType> Type { get; set; }
        [ModelProperty("broadcaster_type")]
        public Optional<BroadcasterType> BroadcasterType { get; set; }
        [ModelProperty("description")]
        public Optional<Utf8String> Description { get; set; }
        [ModelProperty("profile_image_url")]
        public Optional<Utf8String> ProfileImageUrl { get; set; }
        [ModelProperty("offline_image_url")]
        public Optional<Utf8String> OfflineImageUrl { get; set; }
        [ModelProperty("email")]
        public Optional<Utf8String> Email { get; set; }
        [ModelProperty("view_count")]
        public Optional<uint> TotalViews { get; set; }
    }
}
