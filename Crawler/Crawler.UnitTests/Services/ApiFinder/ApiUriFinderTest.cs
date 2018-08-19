using System.IO;
using Crawler.Services;
using Crawler.Services.ApiFinder;
using Moq;
using NFluent;
using NUnit.Framework;

namespace Crawler.UnitTests.Services.ApiFinder
{
    [TestFixture]
    public class ApiUriFinderTest
    {
        private Mock<IApiClient> Client { get; set; }
        private string JsonContent { get; set; }

        [SetUp]
        public void Init()
        {
            Client = new Mock<IApiClient>();
            JsonContent = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Services/ApiFinder/discoveringResult.txt"));
        }

        [Test]
        public void ExtractApiIdEndpoint_ReturnIdContainedInTheResponse()
        {
            var apiUriFinder = new ApiUriFinder(Client.Object);

            var result = apiUriFinder.ExtractApiIdEndpoint(JsonContent);

            Check.That(result).IsEqualTo(435774672);
        }

        [Test]
        public void Find_GetTheCorrectApiUriToCall()
        {
            Client.Setup(_ => _.GetResponseFromUri(It.IsAny<string>())).ReturnsAsync(JsonContent);

            var apiUriFinder = new ApiUriFinder(Client.Object);
            var result = apiUriFinder.Find("");

            Check.That(result.Result).IsEqualTo("https://www.unibet.fr/zones/automaticcoupon/display-markets.json?nodeId=435774672&type=R%25C3%25A9sultat");
        }
    }
}
