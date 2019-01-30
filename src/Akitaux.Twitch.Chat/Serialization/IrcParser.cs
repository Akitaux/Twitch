using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Voltaic;
using Voltaic.Serialization;
using Voltaic.Serialization.Utf8;

namespace Akitaux.Twitch.Chat.Serialization
{
    public static class IrcParser
    {
        public static ResizableMemory<byte> Write(IrcMessage message, Utf8Serializer serializer)
        {
            var tags = new List<string>();
            if (message.Tags.IsSpecified)
            {
                foreach (var pair in message.Tags.Value)
                    tags.Add($"{pair.Key}={pair.Value}");
            }

            var fieldInfo = typeof(IrcCommand).GetTypeInfo().GetDeclaredField(Enum.GetName(typeof(IrcCommand), message.Command));
            var attribute = fieldInfo.GetCustomAttribute<ModelEnumValueAttribute>();
            var command = attribute.Key;

            var payload = new Utf8String((tags.Count > 0 ? "@" + string.Join(";", tags) + " :" : "") + $"{command} {string.Join(" ", message.Parameters)}");
            return serializer.Write(payload);
        }

        public static IrcMessage Read(ReadOnlySpan<byte> bytes, Utf8Serializer serializer)
        {
            var content = serializer.Read<string>(bytes);
            var msg = new IrcMessage();
            
            // Read Tags
            if (bytes[0] == (byte)'@')
            {
                msg.Tags = new Dictionary<string, string>();
                int tagEnd = bytes.IndexOf((byte)' ');
                var tagBytes = bytes.Slice(1, tagEnd);
                bytes = bytes.Slice(tagEnd + 1);

                int keyValueStart = 0;
                int keyLength = 0;
                for (int i = 0; i < tagBytes.Length; i++)
                {
                    byte c = tagBytes[i];
                    if (c == (byte)'=')
                    {
                        keyLength = i - keyValueStart;
                        continue;
                    }
                    if (c == (byte)';' || c == (byte)' ') // ';' for separator, ' ' for end of tags
                    {
                        int valueLength = i - keyValueStart - keyLength;
                        var key = serializer.Read<string>(tagBytes.Slice(keyValueStart, keyLength));
                        var value = serializer.Read<string>(tagBytes.Slice(keyValueStart + keyLength + 1, valueLength - 1));

                        msg.Tags.Value.Add(key, value);
                        keyValueStart = i + 1;
                    }
                }
            }
            
            // Read Prefix
            if (bytes[0] == (byte)':')
            {
                int prefixEnd = bytes.IndexOf((byte)' ');
                var prefixBytes = bytes.Slice(1, prefixEnd - 1);
                bytes = bytes.Slice(prefixEnd + 1);

                msg.Prefix = serializer.Read<Utf8String>(prefixBytes);
            }

            // Read Command
            int commandEnd = bytes.IndexOf((byte)' ');
            var commandBytes = bytes.Slice(0, commandEnd);
            bytes = bytes.Slice(commandEnd + 1);

            msg.CommandRaw = serializer.Read<Utf8String>(commandBytes);
            var fieldInfo = typeof(IrcCommand).GetFields()
                .FirstOrDefault(x => x.GetCustomAttributes<ModelEnumValueAttribute>().Any(y => y.Key == msg.CommandRaw.ToString()));
            if (fieldInfo != null)
                msg.Command = (IrcCommand)fieldInfo.GetValue(null);

            // Read Parameters
            var parameters = new List<Utf8String>();
            while (bytes.Length != 0)
            {
                int parameterEnd = bytes.IndexOf((byte)' ');
                
                if (bytes[0] == (byte)':')
                {
                    parameterEnd = -1;
                    bytes = bytes.Slice(1);
                }
                
                ReadOnlySpan<byte> parameterBytes;
                if (parameterEnd == -1)
                {
                    parameterBytes = bytes.Slice(0, bytes.Length - 2); // Read to end and remove trailing newlines
                    parameterEnd = bytes.Length - 1;
                }
                else
                    parameterBytes = bytes.Slice(0, parameterEnd);
                
                parameters.Add(serializer.Read<Utf8String>(parameterBytes));
                bytes = bytes.Slice(parameterEnd + 1);
            }

            msg.Parameters = parameters;
            return msg;
        }
    }
}
