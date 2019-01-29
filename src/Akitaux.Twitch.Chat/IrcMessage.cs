using System.Collections.Generic;
using Voltaic;

namespace Akitaux.Twitch.Chat
{
    public class IrcMessage
    {
        public Optional<Dictionary<string, string>> Tags { get; set; }
        public Utf8String Prefix { get; set; }
        public IrcCommand Command { get; set; }
        public Utf8String CommandRaw { get; set; }
        public List<Utf8String> Parameters { get; set; }

        public IrcMessage() { }
        public IrcMessage(IrcCommand cmd, params string[] parameters)
        {
            Command = cmd;

            var prs = new List<Utf8String>();
            foreach (var parameter in parameters)
                prs.Add(new Utf8String(parameter));

            Parameters = prs;
        }
        public IrcMessage(IrcCommand cmd, params Utf8String[] parameters)
        {
            Command = cmd;
            Parameters = new List<Utf8String>(parameters);
        }
    }
}
