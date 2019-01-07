using System.Collections.Generic;
using Voltaic;

namespace Akitaux.Twitch.Helix.Requests
{
    public class CreateGrantsUploadUrlParams : Rest.QueryMap
    {
        public Utf8String ManifestId { get; set; }
        public Utf8String Type { get; } = new Utf8String("bulk_drops_grant"); // This is the only supported value :)

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            dict["manifest_id"] = ManifestId;
            dict["type"] = Type;
            return dict;
        }

        public void Validate()
        {
            Preconditions.NotNullOrWhitespace(ManifestId.ToString(), nameof(ManifestId));
        }
    }
}
