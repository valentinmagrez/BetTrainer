using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BetService.Models;

namespace BetService.Pages.Admin.Competition
{
    public class DetailsModel : PageModel
    {
        private readonly BetDbContext _context;

        public DetailsModel(BetDbContext context)
        {
            _context = context;
        }

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
    }
}
