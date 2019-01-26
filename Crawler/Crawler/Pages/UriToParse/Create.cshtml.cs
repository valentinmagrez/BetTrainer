using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Crawler.Models.Entity;

namespace Crawler.Pages.UriToParse
{
    public class CreateModel : PageModel
    {
        private readonly Crawler.Models.ApplicationDbContext _context;

        public CreateModel(Crawler.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UriBetsToParse UriBetsToParse { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UrisBetsToParse.Add(UriBetsToParse);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}