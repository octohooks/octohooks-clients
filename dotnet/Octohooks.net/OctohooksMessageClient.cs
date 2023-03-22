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

        public async Task<Message?> Create(string applicationId, MessageRequest messageRequest, string idempotencyKey = null)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                Content = JsonContent.Create(messageRequest),
                Method = HttpMethod.Post,
                RequestUri = new Uri(_httpClient.BaseAddress, $"applications/{applicationId}/messages"),
            };

            httpRequestMessage.Headers.Authorization = _httpClient.DefaultRequestHeaders.Authorization;

            if (!string.IsNullOrEmpty(idempotencyKey))
            {
                httpRequestMessage.Headers.Add("Idempotency-Key", idempotencyKey); 
            }

            var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("unable to create message");
            }

            return await httpResponseMessage.Content.ReadFromJsonAsync<Message>();
        }
    }
}
