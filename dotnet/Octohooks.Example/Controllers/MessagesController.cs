using Microsoft.AspNetCore.Mvc;
using Octohooks.Example.Domain.Services;
using Octohooks.Example.Requests;
using Octohooks.net;
using Octohooks.net.Requests;

namespace Octohooks.Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly ILogger<MessagesController> _logger;

        private readonly MessageService _messageService;

        private readonly OctohooksClient _octohooksClient;

        public MessagesController(ILogger<MessagesController> logger, MessageService messageService, OctohooksClient octohooksClient)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));

            _octohooksClient = octohooksClient ?? throw new ArgumentNullException(nameof(octohooksClient));
        }

        [HttpPost]
        public async Task<IActionResult> Post(MessagesPostRequest request)
        {
            var message = await _messageService.SendSms(request.MobileNumber, request.Body);

            await _octohooksClient.Message.Create(GetApplicationIdFromToken(), new MessageRequest
            {
                Channels = new string[] { },
                EventType = "message.sent",
                Payload = message,
                Uid = message.Id.ToString(),
            });

            return Ok(message);
        }

        private string GetApplicationIdFromToken()
        {
            return "tenant-1";
        }
    }
}