using System.Diagnostics;
using System.Threading.Tasks;
using Crawler.Models.Serializer;
using Crawler.Services.ApiFinder;

namespace Crawler.Services.ApiConsumer.UnibetConsumer
{
    public class GetBets
    {
        private readonly IApiUriFinder _apiFinder;
        private readonly IApiClient _apiClient;
        private readonly EventJsonSerializer _eventSerializer;

        public GetBets()
        {
            _apiFinder = new ApiUriFinder(new ApiClient());
            _apiClient = new ApiClient();
            _eventSerializer = new EventJsonSerializer();
        }

        public async Task Call(string uri)
        {
            var apiUri = await _apiFinder.Find(uri);
            if (apiUri == null)
                return;

            var jsonResponse = await _apiClient.GetResponseFromUri(apiUri);
            _eventSerializer.JsonInput = jsonResponse;
            var events = _eventSerializer.Deserialize();

            events.ForEach(_=>Debug.WriteLine(_));
        }
    }
}
