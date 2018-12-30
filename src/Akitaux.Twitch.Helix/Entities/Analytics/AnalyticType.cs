using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix.Entities
{
    public enum AnalyticType
    {
        [ModelEnumValue("overview_v1")]
        OverviewV1,
        [ModelEnumValue("overview_v2")]
        OverviewV2
    }
}
