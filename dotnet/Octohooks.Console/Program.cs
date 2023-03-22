// See https://aka.ms/new-console-template for more information
using Octohooks.net;
using Octohooks.net.Requests;

var octohooksClient = new OctohooksClient("key_w7ucyhbq936ywlsmhsrs0s663nw718h02fgh147ufxd9uqxq");

var result = octohooksClient.Message.Create("octohooks", new MessageRequest
{
    Channels = new string[0],
    EventType = "user.created",
    Payload = new 
    {
        Email = "foo.bar@example.com"
    },
    Uid = "my-message-id"
}).GetAwaiter().GetResult();

Console.WriteLine(result.Id);

Console.ReadLine();
