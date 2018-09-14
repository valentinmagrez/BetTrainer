using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crawler.Models;
using Crawler.Models.Entity;
using Crawler.Services.ApiConsumer.UnibetConsumer;
using Microsoft.EntityFrameworkCore;

namespace Crawler.Tasks
{
    public class RetrieveBetsTask : IRetrieveBetsTask
    {
        //private readonly List<string> _uriList = new List<string>
        //{
        //    "https://www.unibet.fr/sport/basketball/nba",
        //    "https://www.unibet.fr/sport/football/ligue-1-conforama/ligue-1-matchs"
        //};

        private List<UriBetsToParse> _uriToParse;

        private List<UriBetsToParse> UrisToParse
        {
            get
            {
                if (_uriToParse is null)
                    _uriToParse = _context.UrlsBetsToParse.ToList();

                return _uriToParse;
            }
        }

        private readonly GetBets _getBets;

        private readonly ApplicationDbContext _context;

        public RetrieveBetsTask(ApplicationDbContext ctx)
        {
            _context = ctx;
            _getBets = new GetBets();
        }

        public async Task Start()
        {
            foreach (var uri in UrisToParse)
            {
                await _getBets.Call(uri.Value);
            }
        }
    }
}
