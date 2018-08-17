using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler.Services.ApiFinder
{
    public class ApiUriFinder
    {
        public ApiUriFinder()
        {
            UriCalling = "https://www.unibet.fr/sport/football/ligue-1-conforama/ligue-1-matchs";
        }

        public string UriCalling { get; set; }

        public async Task<decimal> Find()
        {
            var response = await GetResponseFromUri();
            return ExtractApiIdEndpoint(response);
        }

        public decimal ExtractApiIdEndpoint(string content)
        {
            var regex = new Regex(@"nodeId(?:\s)*:(?:\s)*([0-9]+),");
            var resultRegex = regex.Match(content).Groups[1].Value;

            return decimal.Parse(resultRegex);
        }

        private async Task<string> GetResponseFromUri()
        {
            var client = new HttpClient
            {
                DefaultRequestHeaders = {Accept = {new MediaTypeWithQualityHeaderValue("application/json")}}
            };
            var response = await client
                .GetAsync(UriCalling);

            if (!response.IsSuccessStatusCode)
                return null;

            var content = response.Content;
            var json = content.ReadAsStringAsync();

            return await json;
        }
    }
}
