using System.Threading.Tasks;
using Crawler.Models.Entity;

namespace Crawler.Tasks
{
    public interface IRetrieveBetsTask
    {
        Task Start();
        Task Start(UriBetsToParse uri);
    }
}