# Octohooks.Example

## Install

Install the library

```bash
dotnet add package Octohooks.net
```

## Configure

```csharp
builder.Services
    .AddTransient((serviceProvider) => new OctohooksClient("key_qbj411vu4h32qnlxyuynox89ocomdj73vz4wzflj45q8ybch"));
```

## Implement

````csharp
[HttpPost]
[Route("{code}/redemption")]
public async Task<IActionResult> Post(string code)
{
    // This is your application ID or the user-defined ID of the application
    // It's recommended that you create an application for each of your users and obtain the application ID from
    // their Auth Token, JWT or headers. 
    var applicationId = "my-application";

    // TODO
    // This will be your own logic such as redemption of the voucher
    // 
    // 
    // 

    await _octohooksClient.Message.Create(applicationId, new MessageRequest
    {
        Channels = new string[] { },
        EventType = "voucher.redeemed",
        Payload = new { code },
        Uid = Guid.NewGuid().ToString(),
    });

    return Accepted();
}
```
