using System.Threading.Tasks;

namespace Crawler.Services.ApiFinder
{
    public interface IApiUriFinder
    {
        Task<string> Find(string uriCalled);
    }
}