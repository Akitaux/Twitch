using System;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Rest.Entities
{
    public class DateRange
    {
        [ModelProperty("started_at")]
        public DateTime StartedAt { get; set; }
        [ModelProperty("ended_at")]
        public DateTime EndedAt { get; set; }
    }
}
