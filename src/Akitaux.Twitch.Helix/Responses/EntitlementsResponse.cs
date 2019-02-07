using Voltaic.Serialization;

namespace Akitaux.Twitch.Helix
{
    public class EntitlementsResponse<T> where T : class
    {
        [ModelProperty("results")]
        public T[] Results { get; set; }
    }
}
