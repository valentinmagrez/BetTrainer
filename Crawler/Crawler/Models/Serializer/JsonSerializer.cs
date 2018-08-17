using System.Collections.Generic;
using Newtonsoft.Json;

namespace Crawler.Models.Serializer
{
    public class JsonSerializer<T, TConverter> where TConverter : JsonConverter, new()
    {
        public string JsonInput { get; set; }

        public List<T> Deserialize()
        {
            return JsonConvert.DeserializeObject<List<T>>(JsonInput, new TConverter());
        }
    }
}
