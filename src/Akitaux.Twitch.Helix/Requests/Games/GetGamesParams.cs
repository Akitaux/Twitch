using System;
using System.Collections.Generic;
using Voltaic;

namespace Akitaux.Twitch.Helix.Requests
{
    public class GetGamesParams : Rest.QueryMap
    {
        public Optional<ulong[]> GameIds { get; set; }
        public Optional<Utf8String[]> Names { get; set; }

        public override IDictionary<string, object> CreateQueryMap()
        {
            var dict = new Dictionary<string, object>();
            if (GameIds.IsSpecified)
                dict["id"] = GameIds.Value;
            if (Names.IsSpecified)
                dict["name"] = Names.Value;
            return dict;
        }

        public void Validate()
        {
            if (!GameIds.IsSpecified && !Names.IsSpecified)
                throw new ArgumentException($"At least one of the listed parameters must have a value for this request: {nameof(GameIds)} or {nameof(Names)}");

            if (GameIds.IsSpecified)
            {
                Preconditions.CountGreaterThan(GameIds, 100, nameof(GameIds));
                Preconditions.CountLessThan(GameIds, 1, nameof(GameIds));
            }
            if (Names.IsSpecified)
            {
                Preconditions.CountGreaterThan(Names, 100, nameof(Names));
                Preconditions.CountLessThan(Names, 1, nameof(Names));
            }
        }
    }
}
