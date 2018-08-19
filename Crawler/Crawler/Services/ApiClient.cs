using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Crawler.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _client = new HttpClient
        {
            DefaultRequestHeaders = { Accept = { new MediaTypeWithQualityHeaderValue("application/json") } }
        };

        public async Task<string> GetResponseFromUri(string uriCalled)
        {
            var response = await _client.GetAsync(uriCalled);

            if (!response.IsSuccessStatusCode)
                return null;

            var content = response.Content;
            var json = content.ReadAsStringAsync();

            return await json;
        }
    }
}
