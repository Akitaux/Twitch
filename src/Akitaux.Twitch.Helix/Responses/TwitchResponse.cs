using Akitaux.Twitch.Rest.Entities;
using System.Collections.Generic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix
{
    public class TwitchResponse<T>
    {
        [ModelProperty("data")]
        public Optional<List<T>> Data { get; set; }
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
        public string Cursor { get; set; }
    }
}
