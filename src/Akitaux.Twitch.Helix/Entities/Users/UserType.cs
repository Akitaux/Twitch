using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    [ModelStringEnum]
    public enum UserType
    {
        [ModelEnumValue("", type: EnumValueType.ReadOnly)]
        None = -1,
        [ModelEnumValue("global_mod")]
        GlobalMod,
        [ModelEnumValue("staff")]
        Staff,
        [ModelEnumValue("admin")]
        Admin
    }
}
