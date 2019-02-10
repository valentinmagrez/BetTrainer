using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BetService.Pages.Admin.Bet
{
    public class CreateModel : PageModel
    {
        private readonly Models.BetDbContext _context;

        public CreateModel(Models.BetDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Bet Bet { get; set; }

        public SelectList BetCategorySelectList { get; set; }
        public SelectList EventSelectList { get; set; }

        public IActionResult OnGet()
        {
            var categories = _context.BetCategory.AsNoTracking();
            BetCategorySelectList = new SelectList(categories, "Id", "Name");

            var events = _context.Event.AsNoTracking();
            EventSelectList = new SelectList(events, "Id", "Name");
            return Page();
        }

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