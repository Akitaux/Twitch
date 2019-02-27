namespace Akitaux.Twitch.Pubsub
{
    public struct Topic
    {
        public PubsubDispatchType DispatchType { get; set; }
        public ulong Id { get; set; }

        public Topic(PubsubDispatchType dispatchType, ulong id)
        {
            DispatchType = dispatchType;
            Id = id;
        }
    }
}
