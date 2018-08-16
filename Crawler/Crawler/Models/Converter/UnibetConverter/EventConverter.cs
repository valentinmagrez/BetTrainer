using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crawler.Models.Converter.UnibetConverter
{
    public class BetConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var result = new List<Bet>();
            if (reader.TokenType != JsonToken.StartArray) return null;

            var selectionJsonArray = JArray.Load(reader);

            foreach (var selection in selectionJsonArray.ToList())
            {
                var bet = new Bet
                {
                    Name = selection["name"].ToString(),
                    Odd = ComputeOdd(decimal.Parse(selection["currentPriceUp"].ToString()),
                        decimal.Parse(selection["currentPriceDown"].ToString())),
                    Percentage = decimal.Parse(selection["selPercentage"].ToString())
                };
                result.Add(bet);
            }
            return result;
        }

        private decimal ComputeOdd(decimal profit, decimal amountBet)
        {
            return (profit / amountBet) + 1;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(List<Bet>).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }
    }
    public class EventConverter : JsonConverter
    {
        private BetJsonDeserializer _betDeserializer = new BetJsonDeserializer();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var result = new List<Event>();
            if (reader.TokenType != JsonToken.StartObject) return null;

            var  item = JObject.Load(reader);

            var eventByTimestampJson = ExtractEventByTimeStamp(item);

            foreach (var timestamp in eventByTimestampJson)
            {
                var events = timestamp.First().Children();
                foreach (var betEveent in events)
                {
                    result.Add(new Event
                    {
                        BetAvailables = DeserializeBets(betEveent["selections"].ToString()),
                        BetType = betEveent["marketName"].ToString(),
                        CompetitionName = betEveent["competitionName"].ToString(),
                        //EndDate = TimestampToDatetime(betEveent["betEndDate"].ToString()),
                        Name = betEveent["eventName"].ToString(),
                        Sport = betEveent["sport"].ToString(),
                        //StartDate = TimestampToDatetime(betEveent["eventStartDate"].ToString()),
                    });
                }
            }

            foreach(var eventResult in result)
                Console.WriteLine(eventResult);

            return result;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(List<Event>).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public IList<JToken> ExtractEventByTimeStamp(JToken jsonObject)
        {
            return jsonObject["marketsByType"]["Résultat du match"].Children().ToList();
        }

        private DateTime TimestampToDatetime(string timestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Double.Parse(timestamp));
        }

        private IList<Bet> DeserializeBets(string betsJson)
        {
            _betDeserializer.JsonInput = betsJson;
            var bets = _betDeserializer.Deserialize();

            return bets;
        }
    }
}
