using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    [ModelStringEnum]
    public enum VideoType
    {
        [ModelEnumValue("all", type: EnumValueType.ReadOnly)]
        All,
        [ModelEnumValue("upload")]
        Upload,
        [ModelEnumValue("archive")]
        Archive,
        [ModelEnumValue("highlight")]
        Highlight
    }
}
