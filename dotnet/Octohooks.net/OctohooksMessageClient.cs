using Octohooks.net.Domain.Entities;
using Octohooks.net.Requests;
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

        public async Task<Message?> Create(string applicationId, MessageRequest messageRequest)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync($"applications/{applicationId}/messages", messageRequest);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("unable to create message");
            }

            return await httpResponseMessage.Content.ReadFromJsonAsync<Message>();
        }
    }
}
