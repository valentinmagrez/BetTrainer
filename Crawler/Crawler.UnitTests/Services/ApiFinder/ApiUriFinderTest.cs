using System.IO;
using Crawler.Services.ApiFinder;
using NFluent;
using NUnit.Framework;

namespace Crawler.UnitTests.Services.ApiFinder
{
    [TestFixture]
    public class ApiUriFinderTest
    {
        [Test]
        public void ExtractApiIdEndpoint_ReturnIdContainedInTheResponse()
        {
            var content = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Services/ApiFinder/discoveringResult.txt"));
            
            var apiUriFinder = new ApiUriFinder();

            var result = apiUriFinder.ExtractApiIdEndpoint(content);

            Check.That(result).IsEqualTo(435774672);
        }
    }
}
