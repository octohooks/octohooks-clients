namespace Octohooks.net
{
    public class OctohooksClient
    {
        public readonly OctohooksApplicationClient Application;

        public readonly OctohooksEndpointClient Endpoint;

        public readonly OctohooksMessageClient Message;

        public OctohooksClient(string token) {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://api.octohooks.com/api/v1/");

            // httpClient.BaseAddress = new Uri("http://localhost:8080/api/v1/");

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            Application = new OctohooksApplicationClient(httpClient);

            Message = new OctohooksMessageClient(httpClient);

            Endpoint = new OctohooksEndpointClient(httpClient);
        } 
    }
}