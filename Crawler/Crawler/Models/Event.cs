using System;
using System.Collections.Generic;
using System.Linq;
using Crawler.Models.Converter.UnibetConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crawler.Models
{
    public class Event
    {
        public string CompetitionName { get; set; }
        public string Name { get; set; }
        public string BetType { get; set; }
        public string Sport { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<Bet> BetAvailables { get; set; }

        public override string ToString()
        {
            return $"{Sport} - {CompetitionName} - {BetType} - {Name} - {StartDate} - {Environment.NewLine} {string.Join(",", BetAvailables.Select(x => x.ToString()+ Environment.NewLine).ToArray())}";
        }
    }

    public class EventJsonDeserializer
    {
        public string JsonInput { get; set; }

        public List<Event> Deserialize()
        {
            return JsonConvert.DeserializeObject<List<Event>>(JsonInput, new EventConverter());
        }
    }
}