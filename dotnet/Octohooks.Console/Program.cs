// See https://aka.ms/new-console-template for more information
using Octohooks.net;

Console.WriteLine("Hello, World!");

var octohooksClient = new OctohooksClient("hello-world");

var result = octohooksClient.Message.Create("asasa", new Octohooks.Domain.Entities.Message()).GetAwaiter().GetResult();
