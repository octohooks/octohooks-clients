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
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _octohooksClient = octohooksClient ?? throw new ArgumentNullException(nameof(octohooksClient));
        }

        [HttpPost]
        [Route("{code}/redemption")]
        public async Task<IActionResult> Post(string code)
        {
            var id = RedeemVoucher(code);

            await _octohooksClient.Message.Create(GetApplicationIdFromToken(), new MessageRequest
            {
                Channels = new string[] { },
                EventType = "voucher.redeemed",
                Payload = new
                {
                    code,
                    id,
                },
                Uid = id,
            });

            return Accepted(new
            {
                id
            });
        }

        private string GetApplicationIdFromToken()
        {
            return "tenant-two";
        }

        private string RedeemVoucher(string code)
        {
            return Guid.NewGuid().ToString();
        }
    }
}