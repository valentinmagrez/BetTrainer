using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BetService.Models;

namespace BetService.Pages.Admin.BetCategory
{
    public class DeleteModel : PageModel
    {
        private readonly BetDbContext _context;

        public DeleteModel(BetDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.BetCategory BetCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BetCategory = await _context.BetCategory.FirstOrDefaultAsync(m => m.Id == id);

            if (BetCategory == null)
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

            BetCategory = await _context.BetCategory.FindAsync(id);

            if (BetCategory != null)
            {
                _context.BetCategory.Remove(BetCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
