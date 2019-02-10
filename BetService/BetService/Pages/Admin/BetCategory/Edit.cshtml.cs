using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BetService.Models;

namespace BetService.Pages.Admin.BetCategory
{
    public class EditModel : PageModel
    {
        private readonly BetDbContext _context;

        public EditModel(BetDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.BetCategory BetCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BetCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BetCategoryExists(BetCategory.Id))
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

        private bool BetCategoryExists(Guid id)
        {
            return _context.BetCategory.Any(e => e.Id == id);
        }
    }
}
