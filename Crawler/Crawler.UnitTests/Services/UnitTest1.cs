using System.Collections.Generic;
using System.IO;
using System.Linq;
using Crawler.Models;
using Crawler.Models.Converter.UnibetConverter;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NFluent;
using NUnit.Framework;

namespace Crawler.UnitTests.Services
{
    [TestFixture]
    public class UnitTest1
    {
        public string JsonInput { get; set; }

        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void TestMethod1()
        {
            JsonInput = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Services/result.json"));
            var deserializer = new EventJsonDeserializer {JsonInput = JsonInput};
            deserializer.Deserialize();
        }

        [Test]
        public void DeserialiseBetSample_ReturnExpectedBetsList()
        {
            var expectedBets = new List<Bet>
            {
                new Bet{Name = "Reims", Odd = (decimal) 4.75, Percentage = 1},
                new Bet{Name = "Match nul", Odd = (decimal) 3.85, Percentage = 3},
                new Bet{Name = "Lyon", Odd = (decimal) 1.67, Percentage = 96},
            };
            
            JsonInput = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Services/resultBetSelections.json"));
            var deserializer = new BetJsonDeserializer { JsonInput = JsonInput };
            var bets = deserializer.Deserialize();

            Check.That(bets).ContainsExactly(expectedBets);
        }

        private bool ListsOfBetEqual(IEnumerable<Bet> list1, IEnumerable<Bet> list2)
        {
            return list1.SequenceEqual(list2);
        }
    }
}
