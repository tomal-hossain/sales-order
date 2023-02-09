using System.Text;
using System.Net.Http.Json;
using System.Text.Json;

namespace Web.Service
{
    public interface IHttpService
    {
        Task<T> Get<T>(string uri);
        Task<T> Post<T>(string uri, object value);
		Task<T> Delete<T>(string uri);
	}

    public class HttpService: IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> Get<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return await SendRequest<T>(request);
        }

        public async Task<T> Post<T>(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json")
            };
            return await SendRequest<T>(request);
        }

		public async Task<T> Delete<T>(string uri)
		{
			var request = new HttpRequestMessage(HttpMethod.Delete, uri);
			return await SendRequest<T>(request);
		}

		private async Task<T> SendRequest<T>(HttpRequestMessage request)
        {
            using var response = await _httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.Content.ToString());
            }
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
