using System;
using System.Reflection;
using System.Xml;
using Voltaic;
using Voltaic.Serialization;

namespace Akitaux.Twitch
{
    public class DateTimeConverter : ValueConverter<DateTime>
    {
        private readonly ValueConverter<string> _valueConverter;

        public DateTimeConverter(Serializer serializer, PropertyInfo propInfo)
        {
            _valueConverter = serializer.GetConverter<string>(propInfo, true);
        }
        
        public override bool TryRead(ref ReadOnlySpan<byte> remaining, out DateTime result, PropertyMap propMap = null)
        {
            result = default;
            if (!_valueConverter.TryRead(ref remaining, out var content, propMap))
                return false;
            if (!DateTime.TryParse(content, out DateTime dateTime))
                return false;
            result = dateTime;
            return true;
        }

        public override bool TryWrite(ref ResizableMemory<byte> writer, DateTime value, PropertyMap propMap = null)
            => _valueConverter.TryWrite(ref writer, XmlConvert.ToString(value, XmlDateTimeSerializationMode.Utc));
    }
}
