using System;
using System.Net.Http;
using System.Net.Http.Headers;
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
                BaseAddress = new Uri("https://www.unibet.fr/"),
                DefaultRequestHeaders = {Accept = {new MediaTypeWithQualityHeaderValue("application/json")}}
            };

            var response = client
                .GetAsync("zones/automaticcoupon/display-markets.json?nodeId=435774672&type=R%25C3%25A9sultat").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content;
                var json = content.ReadAsStringAsync();
            }
            else
            {
                //Something has gone wrong, handle it here
            }
        }
    }
}
