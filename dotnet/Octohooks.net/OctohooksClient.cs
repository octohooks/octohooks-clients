namespace Octohooks.net
{
    public class OctohooksClient
    {
        public readonly OctohooksMessageClient Message;

        public OctohooksClient(string token) {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://api.octohooks.com/api/v1/");

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            Message = new OctohooksMessageClient(httpClient);
        } 
    }
}