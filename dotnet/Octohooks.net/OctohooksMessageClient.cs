using Octohooks.Domain.Entities;
using System.Net.Http.Json;

namespace Octohooks.net
{
    public class OctohooksMessageClient
    {
        protected readonly HttpClient _httpClient;

        public OctohooksMessageClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));   
        }

        public async Task<Message> Create(string applicationId, Message message)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync($"applications/${applicationId}/messages", message);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            return message;
        }
    }
}
