using System.Threading.Tasks;

namespace Crawler.Services
{
    public interface IApiClient
    {
        Task<string> GetResponseFromUri(string uriCalled);
    }
}