using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public enum VideoPeriod
    {
        [ModelEnumValue("all")]
        All,
        [ModelEnumValue("day")]
        Day,
        [ModelEnumValue("week")]
        Week,
        [ModelEnumValue("month")]
        Month
    }
}
