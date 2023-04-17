using Microsoft.AspNetCore.Mvc;
using Octohooks.net;
using Octohooks.net.Requests;

namespace Octohooks.Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RefundsController : ControllerBase
    {
        private readonly OctohooksClient _octohooksClient;

        public RefundsController(OctohooksClient octohooksClient)
        {
            _octohooksClient = octohooksClient ?? throw new ArgumentNullException(nameof(octohooksClient));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string id)
        {
            await _octohooksClient.Message.Create(GetApplicationIdFromToken(), new MessageRequest
            {
                Channels = new string[] { },
                EventType = "refund.pending",
                Payload = new {
                    Id = id
                },
                Uid = id.ToString(),
            });

            return Ok();
        }

        private string GetApplicationIdFromToken()
        {
            return "tenant-1";
        }
    }
}