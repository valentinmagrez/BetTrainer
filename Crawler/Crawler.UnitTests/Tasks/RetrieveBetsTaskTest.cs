using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crawler.Models;
using Crawler.Models.Entity;
using Crawler.Services.ApiConsumer.UnibetConsumer;
using Crawler.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace Crawler.UnitTests.Tasks
{
    [TestFixture]
    public class RetrieveBetsTaskTest
    {
        [Test]
        public async Task ExtractApiIdEndpoint_ReturnIdContainedInTheResponse()
        {
            var data = new List<UriBetsToParse>
            {
                new UriBetsToParse{ Value = "uri1"},
                new UriBetsToParse { Value = "uri2" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UriBetsToParse>>();
            mockSet.As<IQueryable<UriBetsToParse>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UriBetsToParse>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UriBetsToParse>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UriBetsToParse>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.UrisBetsToParse).Returns(mockSet.Object);

            var mockGetBetService = new Mock<IGetBets>();

            var service = new RetrieveBetsTask(mockContext.Object)
            {
                GetBets = mockGetBetService.Object
            };
            
            await service.Start();

            mockGetBetService.Verify(_ => _.Call("uri1"));
            mockGetBetService.Verify(_ => _.Call("uri2"));
        }
    }
}
