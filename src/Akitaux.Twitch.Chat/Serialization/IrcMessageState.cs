using System;
using System.Collections.Generic;
using System.Text;

namespace Akitaux.Twitch.Chat.Serialization
{
    public enum IrcMessageState
    {
        None,
        Tags,
        Prefix,
        Command,
        Parameter,
        Remainder,
        Endline
    }
}
