using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
}