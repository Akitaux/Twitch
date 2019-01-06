using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Rest
{
    public class RestError
    {
        [ModelProperty("status")]
        public int Status { get; set; }
        [ModelProperty("error")]
        public Utf8String Error { get; set; }
        [ModelProperty("message")]
        public Utf8String Message { get; set; }
    }
}
