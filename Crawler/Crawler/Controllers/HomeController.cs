using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Crawler.Models;
using Crawler.Tasks;

namespace Crawler.Controllers
{
    public class HomeController : Controller
    {
        readonly IRetrieveBetsTask _retrieveBetsTaskService;

        public HomeController(IRetrieveBetsTask retrieveBetsTaskService)
        {
            _retrieveBetsTaskService = retrieveBetsTaskService;
        }

        public async Task<IActionResult> Index()
        {
            await _retrieveBetsTaskService.Start();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
    }
}
