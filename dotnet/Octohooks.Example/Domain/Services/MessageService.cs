using Octohooks.Example.Domain.Entities;

namespace Octohooks.Example.Domain.Services
{
    public class MessageService
    {
        public async Task<Message> SendSms(string mobileNumber, string body)
        {
            return new Message
            {
                Id = Guid.NewGuid(),
                MobileNumber = mobileNumber,
            };
        }
    }
}
