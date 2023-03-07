// See https://aka.ms/new-console-template for more information
using Octohooks.net;
using Octohooks.net.Domain.Entities;

Console.WriteLine("Hello, World!");

var octohooksClient = new OctohooksClient("hello-world");

var result = octohooksClient.Message.Create("asasa", new Message()
{
    Channels = new string[0],
    EventType = "user.created",
    Payload = new 
    {
        Email = "foo.bar@example.com"
    }
}).GetAwaiter().GetResult();
