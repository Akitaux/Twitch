using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub
{
    public class PubsubPayload
    {
        [ModelProperty("type")]
        public PubsubOperation Operation { get; set; }
        [ModelProperty("nonce", ExcludeNull = true, ExcludeDefault = true)]
        public Optional<Utf8String> Nonce { get; set; }
        [ModelProperty("error", ExcludeNull = true, ExcludeDefault = true)]
        public Optional<Utf8String> Error { get; set; }
        [ModelProperty("data", ExcludeNull = true, ExcludeDefault = true)]
        public Optional<PubsubData> Data { get; set; }
    }

    public class PubsubData
    {
        [ModelProperty("topic")]
        public Topic Topic { get; set; }
        [ModelProperty("data")]
        public Utf8String Data { get; set; }

        [ModelProperty("message", ExcludeNull = true, ExcludeDefault = true)]
        private Utf8String Message
        {
            get { return Data; }
            set { Data = value; }
        }
    }
}
