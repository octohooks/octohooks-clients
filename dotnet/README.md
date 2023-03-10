# Octohooks (DotNet)

## Getting Started

### Installation

Install the package with:

```sh
dotnet add package Octohooks.net
# or
NuGet\Install-Package Octohooks.net
```

### Usage

```csharp
using Octohooks.net;
using Octohooks.net.Domain.Entities;

var octohooksClient = new OctohooksClient("AUTH_TOKEN");

var message = await octohooksClient.Message.Create("my-application", new Message
{
    Channels = new string[0],
    EventType = "user.created",
    Payload = new 
    {
        Email = "foo.bar@example.com"
    },
    Uid = "my-message-id"
});
```
