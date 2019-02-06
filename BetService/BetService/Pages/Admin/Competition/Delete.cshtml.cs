using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BetService.Models;

namespace BetService.Pages.Admin.Competition
{
    public class DeleteModel : PageModel
    {
        private readonly BetDbContext _context;

        public DeleteModel(BetDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Competition Competition { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Competition = await _context.Competition.FirstOrDefaultAsync(m => m.Id == id);

            if (Competition == null)
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

            Competition = await _context.Competition.FindAsync(id);

            if (Competition != null)
            {
                _context.Competition.Remove(Competition);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
