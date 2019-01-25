using Microsoft.AspNetCore.Mvc;
using Crawler.Models;
using Crawler.Tasks;

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
            return View();
        }
        
    }
}
