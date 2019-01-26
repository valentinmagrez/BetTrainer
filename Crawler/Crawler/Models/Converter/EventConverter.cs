using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Crawler.Models.Entity;
using Crawler.Models.Serializer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Crawler.Models.Converter
{
    public class EventConverter : JsonConverter
    {
        private readonly BetJsonSerializer _betDeserializer = new BetJsonSerializer();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var result = new List<Event>();
            if (reader.TokenType != JsonToken.StartObject) return null;

            var  item = JObject.Load(reader);

            try
            {
                var eventByTimestampJson = ExtractEventByTimeStamp(item);

                foreach (var timestamp in eventByTimestampJson)
                {
                    var events = timestamp.First().Children();
                    foreach (var betEvent in events)
                    {
                        result.Add(new Event
                        {
                            BetAvailables = DeserializeBets(betEvent["selections"].ToString()),
                            BetType = betEvent["marketName"].ToString(),
                            CompetitionName = betEvent["competitionName"].ToString(),
                            Name = betEvent["eventName"].ToString(),
                            Sport = betEvent["sport"].ToString(),
                            StartDate = TimestampToDatetime(betEvent["eventStartDate"].ToString()),
                        });
                    }
                }
            }
            catch (Exception)
            {
                Debug.WriteLine($"Erreur durant la deserialisation du json => {item}");
            }

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

        public static DateTime TimestampToDatetime(string timestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds(Double.Parse(timestamp));
        }

        private IList<Bet> DeserializeBets(string betsJson)
        {
            _betDeserializer.JsonInput = betsJson;
            var bets = _betDeserializer.Deserialize();

            return bets;
        }
    }
}
