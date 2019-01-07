using Akitaux.Twitch.Rest.Entities;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix
{
    public class TwitchResponse<T> where T : class
    {
        [ModelProperty("data")]
        public T[] Data { get; set; }
        [ModelProperty("total")]
        public Optional<int> Total { get; set; }
        [ModelProperty("date_range")]
        public Optional<DateRange> DateRange { get; set; }
        [ModelProperty("pagination")]
        public Optional<Pagination> Pagination { get; set; }
    }

    public class Pagination
    {
        [ModelProperty("cursor")]
        public Utf8String Cursor { get; set; }
    }
}
