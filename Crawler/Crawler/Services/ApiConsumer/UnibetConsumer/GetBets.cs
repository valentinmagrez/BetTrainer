using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using Crawler.Models;
using Crawler.Models.Serializer;

namespace Crawler.Services.ApiConsumer.UnibetConsumer
{
    public class GetBets
    {
        private readonly EventJsonSerializer _deserializer;

        public GetBets()
        {
            _deserializer = new EventJsonSerializer();
        }

        public void Call()
        {
            var client = new HttpClient
            {
                DefaultRequestHeaders = {Accept = {new MediaTypeWithQualityHeaderValue("application/json")}}
            };
            var response = client
                .GetAsync("https://www.unibet.fr/sport/football/ligue-1-conforama/ligue-1-matchs").Result;
       
            if (response.IsSuccessStatusCode)
            {
               var content = response.Content;
                var json = content.ReadAsStringAsync().Result;
                var result = json.ToString();
                var regex = new Regex(@"nodeId(\s)*:(\s)*([0-9]+),");
                var resultRegex = regex.Matches(result);
            }
            //var response = client
            //    .GetAsync("zones/automaticcoupon/display-markets.json?nodeId=435774672&type=R%25C3%25A9sultat").Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    var content = response.Content;
            //    var json = content.ReadAsStringAsync();
            //}
            //else
            //{
            //    //Something has gone wrong, handle it here
            //}
        }
    }
}
