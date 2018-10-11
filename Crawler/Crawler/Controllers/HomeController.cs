using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Crawler.Models;
using Crawler.Models.Entity;
using Crawler.Tasks;
using Crawler.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Crawler.Controllers
{
    public class HomeController : Controller
    {
        readonly IRetrieveBetsTask _retrieveBetsTaskService;
        private readonly ApplicationDbContext _context;

        public HomeController(IRetrieveBetsTask retrieveBetsTaskService, ApplicationDbContext ctx)
        {
            _context = ctx;
            _retrieveBetsTaskService = retrieveBetsTaskService;
        }

        public IActionResult Index()
        {
//            _retrieveBetsTaskService.Start();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public async Task<IActionResult> Contact()
        {
            ViewData["Message"] = "Your contact page.";

            var uris = await _context.UrisBetsToParse.Select(_ => new UriBetsToParseViewModel { UrlToParse = _.Value }).ToListAsync();
            return View(uris);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AddUri(UriBetsToParseViewModel input)
        {
            var newUri = new UriBetsToParse{ Value = input.UrlToParse};
            _context.UrisBetsToParse.Add(newUri);
            _context.SaveChanges();
            return View("About");
        }
    }
}
