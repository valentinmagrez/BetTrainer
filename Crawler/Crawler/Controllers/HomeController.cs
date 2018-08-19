using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Crawler.Models;
using Crawler.Services.ApiConsumer.UnibetConsumer;

namespace Crawler.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var service = new GetBets();
            service.Call();

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
