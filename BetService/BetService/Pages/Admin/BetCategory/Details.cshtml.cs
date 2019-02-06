using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BetService.Models;

namespace BetService.Pages.Admin.BetCategory
{
    public class DetailsModel : PageModel
    {
        private readonly BetDbContext _context;

        public DetailsModel(BetDbContext context)
        {
            _context = context;
        }

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
    }
}
