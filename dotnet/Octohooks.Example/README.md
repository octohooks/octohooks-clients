# Octohooks.Example

## Install

Install the library

```bash
dotnet add package Octohooks.net
```

## Configure

Configure the Octhooks Client

```csharp
builder.Services
    .AddTransient((serviceProvider) => new OctohooksClient("AUTH_TOKEN"));
```

## Implement

````csharp
[HttpPost]
[Route("{code}/redemption")]
public async Task<IActionResult> Post(string code)
{
    // This is your application ID or the user-defined ID of your application
    // It's recommended that you create an application for each of your users and obtain the application ID from
    // their Auth Token, JWT, headers or a custom implementation. 
    var applicationId = GetApplicationId();

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
