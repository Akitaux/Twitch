using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public enum UserType
    {
        None = -1,
        [ModelEnumValue("global_mod")]
        GlobalMod,
        [ModelEnumValue("staff")]
        Staff,
        [ModelEnumValue("admin")]
        Admin
    }
}
