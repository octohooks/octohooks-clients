using Microsoft.AspNetCore.Mvc;
using Octohooks.net;

namespace Octohooks.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var webhook = new Webhook("i9viqa5vxx78hcxh4rwdm8x7791");

            //Request.Headers.TryGetValue("X-Signature", out var headerStringValues);

            //var header = headerStringValues.ToString();

            //using (var streamReader = new StreamReader(Request.Body))
            //{
            //    var body = streamReader.ReadToEnd();

            //    if (!webhook.Verify(header, body))
            //    {
            //        return Unauthorized();
            //    }
            //}

            var header = "t=1680451275,v0=f1ba0b28b46f84172ae8fdbc8b45133307f23702bcb22d47da50621cab3f9ca7";

            var body = "{\"data\":{\"id\":\"1c6a980f-22a0-4081-ad21-aa4277e8a1f0\",\"mobileNumber\":\"0766542813\"},\"id\":\"epmsg_0f157f303cd1c09619c1e289800a008f\",\"type\":\"message.sent\"}";

            if (!webhook.Verify(header, body))
            {
                return Unauthorized();
            }

            return Ok();
        }
    }
}
