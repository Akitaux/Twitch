using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Requests
{
    public class CreateStreamMarkerParams
    {
        public static readonly string[] RequiredScopes = { "user:edit:broadcast" };

        [ModelProperty("user_id")]
        public ulong UserId { get; set; }
        [ModelProperty("description")]
        public Optional<Utf8String> Description { get; set; }
        
        public void Validate()
        {
            if (Description.IsSpecified)
                Preconditions.NotNullOrEmpty(Description.ToString(), nameof(Description));
        }
    }
}
