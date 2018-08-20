using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler.Services.ApiFinder
{
    public class ApiUriFinder : IApiUriFinder
    {
        private readonly string _apiResult =
            "https://www.unibet.fr/zones/automaticcoupon/display-markets.json?nodeId={0}&type=R%25C3%25A9sultat";

        public ApiUriFinder(IApiClient client)
        {
            ApiClient = client;
        }

        public IApiClient ApiClient { get; set; }

        public async Task<string> Find(string uriCalled)
        {
            var response = await ApiClient.GetResponseFromUri(uriCalled);
            var id =  ExtractApiIdEndpoint(response);

            return string.Format(_apiResult, id);
        }

        public decimal ExtractApiIdEndpoint(string content)
        {
            var regex = new Regex(@"nodeId(?:\s)*:(?:\s)*([0-9]+),");
            var resultRegex = regex.Match(content).Groups[1].Value;

            return decimal.Parse(resultRegex);
        }
    }
}
