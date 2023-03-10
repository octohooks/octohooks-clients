// See https://aka.ms/new-console-template for more information
using Octohooks.net;
using Octohooks.net.Domain.Entities;

var octohooksClient = new OctohooksClient("AUTH_TOKEN");

var result = octohooksClient.Message.Create("my-application", new Message
{
    Channels = new string[0],
    EventType = "user.created",
    Payload = new 
    {
        Email = "foo.bar@example.com"
    },
    Uid = "my-message-id"
}).GetAwaiter().GetResult();
