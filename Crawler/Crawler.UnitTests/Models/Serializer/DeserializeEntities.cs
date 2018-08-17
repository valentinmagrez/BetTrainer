using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Crawler.Models;
using Crawler.Models.Serializer;
using NFluent;
using NUnit.Framework;

namespace Crawler.UnitTests.Models
{
    [TestFixture]
    public class DeserializeEntitiesTest
    {
        public string JsonInput { get; set; }
        public List<Bet> ExpectedBets { get; set; }

        [SetUp]
        public void Init()
        {
            ExpectedBets = new List<Bet>
            {
                new Bet{Name = "Reims", Odd = (decimal) 4.75, Percentage = 1},
                new Bet{Name = "Match nul", Odd = (decimal) 3.85, Percentage = 3},
                new Bet{Name = "Lyon", Odd = (decimal) 1.67, Percentage = 96},
            };
        }

        [Test]
        public void DeserializeEventSample_ReturnExpectedEvent()
        {
            var expectedEvent = new Event
            {
                Name = "Reims - Lyon",
                StartDate = new DateTime(2018, 8, 17, 18, 45, 0),
                BetType = "Résultat du match",
                CompetitionName = "France, Ligue 1 Conforama",
                Sport = "FOOTBALL",
                BetAvailables = ExpectedBets,
            };
            JsonInput = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Models/Serializer/result.json"));
            var deserializer = new EventJsonSerializer {JsonInput = JsonInput};
            var events = deserializer.Deserialize();

            Check.That(events.Count).Equals(20);
            Check.That(events.First()).Equals(expectedEvent);
        }

        [Test]
        public void DeserialiseBetSample_ReturnExpectedBetsList()
        {
            JsonInput = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Models/Serializer/resultBetSelections.json"));
            var deserializer = new BetJsonSerializer { JsonInput = JsonInput };
            var bets = deserializer.Deserialize();

            Check.That(bets).ContainsExactly(ExpectedBets);
        }
    }
}
