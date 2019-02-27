using System;
using System.Reflection;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch.Pubsub.Serialization
{
    public class TopicConverter : ValueConverter<Topic>
    {
        private readonly ValueConverter<ulong> _idConverter;
        private readonly ValueConverter<string> _valueConverter;
        private readonly EnumMap<PubsubDispatchType> _map;

        public TopicConverter(Serializer serializer, PropertyInfo propInfo)
        {
            _idConverter = serializer.GetConverter<ulong>(propInfo, true);
            _valueConverter = serializer.GetConverter<string>(propInfo, true);
            _map = EnumMap.For<PubsubDispatchType>();
        }

        public override bool TryRead(ref ReadOnlySpan<byte> remaining, out Topic result, PropertyMap propMap = null)
        {
            result = default;

            int bytesConsumed = 0;
            ReadOnlySpan<byte> dispatchBytes = default;
            ReadOnlySpan<byte> idBytes = default;
            for (int i = 0; i < remaining.Length; i++)
            {
                if (remaining[i] == (byte)'.')
                    dispatchBytes = remaining.Slice(1, i - 1);
                else if (remaining[i] == (byte)'"' && dispatchBytes != default)
                {
                    idBytes = remaining.Slice(dispatchBytes.Length + 2, i - dispatchBytes.Length - 2);
                    bytesConsumed = i + 1;
                    break;
                }
            }

            if (!_map.TryFromKey(dispatchBytes, out PubsubDispatchType enumMapValue))
                return false;
            if (!_idConverter.TryRead(ref idBytes, out var id, propMap))
                return false;

            remaining = remaining.Slice(bytesConsumed);
            result = new Topic(enumMapValue, id);
            return true;
        }

        public override bool TryWrite(ref ResizableMemory<byte> writer, Topic value, PropertyMap propMap = null)
        {
            var dispatchUtf8 = _map.ToUtf8Key(value.DispatchType);
            
            if (_valueConverter.TryWrite(ref writer, dispatchUtf8.ToString() + "." + value.Id)) 
                return true;
            return false;
        }
    }
}