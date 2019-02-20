using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public enum VideoType
    {
        [ModelEnumValue("all")]
        All,
        [ModelEnumValue("upload")]
        Upload,
        [ModelEnumValue("archive")]
        Archive,
        [ModelEnumValue("highlight")]
        Highlight
    }
}
