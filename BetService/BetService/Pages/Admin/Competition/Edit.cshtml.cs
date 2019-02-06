using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BetService.Models;

namespace BetService.Pages.Admin.Competition
{
    public class EditModel : PageModel
    {
        private readonly BetDbContext _context;

        public EditModel(BetDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Competition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitionExists(Competition.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CompetitionExists(long id)
        {
            return _context.Competition.Any(e => e.Id == id);
        }
    }
}
