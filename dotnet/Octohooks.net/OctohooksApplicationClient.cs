using Octohooks.net.Domain.Entities;
using Octohooks.net.Requests;
using System.Net.Http.Json;

namespace Octohooks.net
{
    public class OctohooksApplicationClient
    {
        protected readonly HttpClient _httpClient;

        public OctohooksApplicationClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));   
        }

        public async Task<Application?> Create(ApplicationRequest applicationRequest)
        {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync($"applications", applicationRequest);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("unable to create application");
            }

            return await httpResponseMessage.Content.ReadFromJsonAsync<Application>();
        }

        public async Task<Application?> Find(string applicationId)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"applications/{applicationId}");

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw new Exception("unable to find application");
            }

            return await httpResponseMessage.Content.ReadFromJsonAsync<Application>();
        }
    }
}
