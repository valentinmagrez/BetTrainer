using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BetService.Models;

namespace BetService.Pages.Admin.Sport
{
    public class DetailsModel : PageModel
    {
        private readonly BetDbContext _context;

        public DetailsModel(BetDbContext context)
        {
            _context = context;
        }

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
    }
}
