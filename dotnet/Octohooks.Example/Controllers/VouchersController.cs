using Microsoft.AspNetCore.Mvc;
using Octohooks.net;
using Octohooks.net.Requests;

namespace Octohooks.Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VouchersController : ControllerBase
    {
        private readonly ILogger<VouchersController> _logger;

        private readonly OctohooksClient _octohooksClient;

        public VouchersController(ILogger<VouchersController> logger, OctohooksClient octohooksClient)
        {
            _logger = logger;

            _octohooksClient = octohooksClient ?? throw new ArgumentNullException(nameof(octohooksClient));
        }

        [HttpPost]
        [Route("{code}/redemption")]
        public async Task<IActionResult> Post(string code)
        {
            var applicationId = GetApplicationId(); // Get application ID from Token, JWT, headers or a custom implementation

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

        private string GetApplicationId()
        {
            return "tenant-1";
        }
    }
}