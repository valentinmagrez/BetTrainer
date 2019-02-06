using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BetService.Models;

namespace BetService.Pages.Admin.Sport
{
    public class DeleteModel : PageModel
    {
        private readonly BetDbContext _context;

        public DeleteModel(BetDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Sport Sport { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sport = await _context.Sport.FirstOrDefaultAsync(m => m.Id == id);

            if (Sport == null)
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

            Sport = await _context.Sport.FindAsync(id);

            if (Sport != null)
            {
                _context.Sport.Remove(Sport);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
