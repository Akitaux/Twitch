using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    [ModelStringEnum]
    public enum VideoPeriod
    {
        [ModelEnumValue("all", type: EnumValueType.ReadOnly)]
        All,
        [ModelEnumValue("day")]
        Day,
        [ModelEnumValue("week")]
        Week,
        [ModelEnumValue("month")]
        Month
    }
}
