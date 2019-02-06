using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BetService.Models;

namespace BetService.Pages.Admin.Sport
{
    public class CreateModel : PageModel
    {
        private readonly BetDbContext _context;

        public CreateModel(BetDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Sport Sport { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sport.Add(Sport);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}