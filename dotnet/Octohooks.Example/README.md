# Octohooks.Example

## Introduction

This case involves an .NET Core API that allows clients to send SMS messages via an endpoint. Due to client demand, there is a request to implement webhook functionality in order to receive real-time notification when messages are sent and delivered.

To achieve this objective, we plan to leverage [Octohooks](https://octohooks.com) for adding webhook capabilities to our API. The proposed approach entails generating an individual application for each client in [Octohooks](https://octohooks.com), thereby enabling each client to specify one or more endpoints for receiving events/messages.

![Octohooks](Assets/diagram.png)

## Install

Install the .NET Core library on your project or solution.

```bash
dotnet add package Octohooks.net
```

## Setup

Register the `OctohooksClient` with your dependency injection container.

```csharp
builder.Services
    .AddTransient((serviceProvider) => new OctohooksClient("AUTH_TOKEN"));
```

## Implement

* Ensure the required `using` statements are added to your file.
* Declare the `OctohooksClient` field in your controller `class`.
* Assign the `OctohooksClient` field in the constructor of your controller `class`.
* Use the `OctohooksClient` instance to make a request to [Octohooks](https://octohooks.com) in your controller method(s).

````csharp
using Octohooks.net;
using Octohooks.net.Requests;

[ApiController]
[Route("api/[controller]")]
public class MessagesController : ControllerBase
{
    private readonly OctohooksClient _octohooksClient;

    public MessagesController(OctohooksClient octohooksClient)
    {
        _octohooksClient = octohooksClient ?? throw new ArgumentNullException(nameof(octohooksClient));
    }


    [HttpPost]
    public async Task<IActionResult> Post(MessagesPostRequest request)
    {
        // We'll use the JSON Web Token(JWT) to determine the applicationId of the client making the request
        var applicationId = GetApplicationIdFromToken();

        // Sending the SMS via our domain service
        var message = await _messageService.SendSms(request.MobileNumber, request.Body);

        // Making a request to Octohooks to send the event/message
        await _octohooksClient.Message.Create(applicationId, new MessageRequest
        {
            Channels = new string[] { },
            EventType = "message.sent",
            Payload = message,
            Uid = message.Id.ToString(),
        });

        return Ok(message);
    }
}
```
