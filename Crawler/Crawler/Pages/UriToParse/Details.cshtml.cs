using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crawler.Models;
using Crawler.Models.Entity;
using Crawler.Tasks;

namespace Crawler.Pages.UriToParse
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IRetrieveBetsTask _retrieveBetsTask;

        public DetailsModel(ApplicationDbContext context, IRetrieveBetsTask retrieveBetsTask)
        {
            _context = context;
            _retrieveBetsTask = retrieveBetsTask;
        }

        public UriBetsToParse UriBetsToParse { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var uri = await GetUriFromId(id);
            if (uri is null)
                return NotFound();

            return Page();
        }

        [BindProperty]
        public int Id { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var uri = await GetUriFromId(Id);
            if (uri is null)
                return NotFound();

            await _retrieveBetsTask.Start(uri);
            return Page();
        }
        
        private async Task<UriBetsToParse> GetUriFromId(int? id)
        {
            if (id == null)
            {
                return null;
            }

            UriBetsToParse = await _context.UrisBetsToParse.FirstOrDefaultAsync(m => m.Id == id);

            return UriBetsToParse;
        }
    }
}
