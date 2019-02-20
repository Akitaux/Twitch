using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public enum VideoSort
    {
        [ModelEnumValue("time")]
        Time,
        [ModelEnumValue("trending")]
        Trending,
        [ModelEnumValue("views")]
        Views
    }
}
