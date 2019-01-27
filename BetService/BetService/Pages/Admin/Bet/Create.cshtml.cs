using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetService.Pages.Admin.Bet
{
    public class CreateModel : PageModel
    {
        private readonly Models.BetDbContext _context;

        public CreateModel(Models.BetDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Bet Bet { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BetItems.Add(Bet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}