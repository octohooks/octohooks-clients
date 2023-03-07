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

var octohooksClient = new OctohooksClient("AUTH_TOKEN");

var message = await octohooksClient.Message.Create("my-application", new Octohooks.Domain.Entities.Message {
  Channels: new string[0]
});
```
