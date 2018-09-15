using System.Threading.Tasks;

namespace Crawler.Services.ApiConsumer.UnibetConsumer
{
    public interface IGetBets
    {
        Task Call(string uri);
    }
}