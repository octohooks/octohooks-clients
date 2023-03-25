using Microsoft.AspNetCore.Mvc;
using Octohooks.net;
using Octohooks.net.Requests;

namespace Octohooks.Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly ILogger<ApplicationsController> _logger;

        private readonly OctohooksClient _octohooksClient;

        public ApplicationsController(ILogger<ApplicationsController> logger, OctohooksClient octohooksClient)
        {
            _logger = logger;

            _octohooksClient = octohooksClient ?? throw new ArgumentNullException(nameof(octohooksClient));
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await _octohooksClient.Application.Create(new ApplicationRequest
            {
                Name = "My Application",
                Uid = "my-application",
            });

            await _octohooksClient.Endpoint.Create("my-application", new EndpointRequest
            {
                Channels = new string[] {},
                Enabled = true,
                EventTypes = new string[] {"voucher.redeemed"},
                Headers = new Dictionary<string, string> {},
                Name = "My Endpoint",
                Uid = Guid.NewGuid().ToString(),
                Url = "https://example.com"
            });

            return Ok();
        }
    }
}
