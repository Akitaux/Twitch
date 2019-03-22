[![Discord](https://discordapp.com/api/guilds/257698577894080512/widget.png)](https://discord.gg/yd8x2wM) [![Build status](https://ci.appveyor.com/api/projects/status/8n9p8i48s7opmrdn?svg=true)](https://ci.appveyor.com/project/Aux/twitch) ![MyGet Version](https://img.shields.io/myget/akitaux/vpre/Akitaux.Twitch.Core.svg)

# Twitch

A [Wumpus-style](https://github.com/discord-net/Wumpus.Net), low-level implementation of the Twitch Apis.

### Builds

Development builds of projects that are available for testing can be found by adding this feed to your nuget sources. 

`https://www.myget.org/F/akitaux/api/v3/index.json`


### Samples

##### Helix
Authentication and a basic request to get online streams.
```csharp
var helix = new TwitchHelixClient
{
    Authorization = new AuthenticationHeaderValue("Bearer", "oauth token")
};

var response = await helix.GetStreamsAsync(new GetStreamsParams
{
    UserNames = new[] { (Utf8String)"emongg"), (Utf8String)"timthetatman" }
});

foreach (var stream in response.Data)
    Console.WriteLine($"{stream.UserName} is online! {stream.Title}");
```

##### Chat
Joining a channel and displaying messages in the console.
```csharp
var chat = new TwitchChatClient();

chat.Connected += () =>
{
    chat.Send(new IrcMessage(IrcCommand.Nickname, "justinfan42069"));
    chat.Send(new IrcMessage(IrcCommand.Password, "justinfan42069"));
    chat.Send(new IrcMessage(IrcCommand.Join, "#emongg"));
};
chat.ReceivedPayload += (payload, n) =>
{
    if (payload.Command == IrcCommand.Message)
        Console.WriteLine(string.Join(" ", payload.Parameters));
};

await chat.RunAsync("wss://irc-ws.chat.twitch.tv:443");
```

##### PubSub
Listening to a channel's subscriptions and displaying them in the console
```csharp
var pubsub = new TwitchPubsubClient();

pubsub.Connected += () =>
{
    pubsub.SendListenAsync(
        new Topic(PubsubDispatchType.ChannelSubscriptionV1, 1234567),
        "oauth token");
};
pubsub.ChannelSubscriptionV1 += (sub) =>
{
    Console.WriteLine($"{sub.DisplayName} just subscribed to {sub.ChannelName} for {sub.CumulativeMonths} month(s)!");
};

await pubsub.RunAsync("wss://pubsub-edge.twitch.tv");
```
