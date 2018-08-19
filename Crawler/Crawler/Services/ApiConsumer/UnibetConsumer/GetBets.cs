using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using Crawler.Models.Serializer;
using Crawler.Services.ApiFinder;

namespace Crawler.Services.ApiConsumer.UnibetConsumer
{
    public class GetBets
    {
        private readonly EventJsonSerializer _deserializer;
        private readonly ApiUriFinder _uriFinder;
        private const string _uri = "https://www.unibet.fr/sport/football/ligue-1-conforama/ligue-1-matchs";

        public GetBets()
        {
            _deserializer = new EventJsonSerializer();
            _uriFinder = new ApiUriFinder(new ApiClient());
        }

        public void Call()
        {
            var client = new HttpClient
            {
                DefaultRequestHeaders = {Accept = {new MediaTypeWithQualityHeaderValue("application/json")}}
            };
            var response = client
                .GetAsync("https://www.unibet.fr/sport/football/ligue-1-conforama/ligue-1-matchs").Result;

            if (!response.IsSuccessStatusCode) return;
            var content = response.Content;
            var json = content.ReadAsStringAsync().Result;
            var result = json.ToString();
            var regex = new Regex(@"nodeId(\s)*:(\s)*([0-9]+),");
            var resultRegex = regex.Matches(result);
        }
    }
}
