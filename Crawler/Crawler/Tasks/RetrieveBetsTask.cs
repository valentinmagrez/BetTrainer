using System.Collections.Generic;
using System.Threading.Tasks;
using Crawler.Services.ApiConsumer.UnibetConsumer;

namespace Crawler.Tasks
{
    public class RetrieveBetsTask
    {
        private readonly List<string> _uriList = new List<string>
        {
            "https://www.unibet.fr/sport/basketball/nba",
            "https://www.unibet.fr/sport/football/ligue-1-conforama/ligue-1-matchs"
        };

        private readonly GetBets _getBets;

        public RetrieveBetsTask()
        {
            _getBets = new GetBets();
        }

        public async Task Start()
        {
            foreach (var uri in _uriList)
            {
                await _getBets.Call(uri);
            }
        }
    }
}
