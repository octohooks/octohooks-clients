using Octohooks.net.Domain.Entities;
using Octohooks.net.Requests;
using System.Net.Http.Json;

namespace Octohooks.net
{
    public class OctohooksEndpointClient
    {
        protected readonly HttpClient _httpClient;

        public OctohooksEndpointClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));   
        }

        public async Task<Endpoint?> Create(string applicationId, EndpointRequest endpointRequest)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync($"applications/{applicationId}", endpointRequest);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("unable to create endpoint");
            }

            return await httpResponseMessage.Content.ReadFromJsonAsync<Endpoint>();
        }
    }
}
