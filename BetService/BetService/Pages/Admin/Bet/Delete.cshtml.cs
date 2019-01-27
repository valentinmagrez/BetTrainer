using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BetService.Pages.Admin.Bet
{
    public class DeleteModel : PageModel
    {
        private readonly Models.BetDbContext _context;

        public DeleteModel(Models.BetDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Bet Bet { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bet = await _context.BetItems.FirstOrDefaultAsync(m => m.Id == id);

            if (Bet == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bet = await _context.BetItems.FindAsync(id);

            if (Bet != null)
            {
                _context.BetItems.Remove(Bet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
