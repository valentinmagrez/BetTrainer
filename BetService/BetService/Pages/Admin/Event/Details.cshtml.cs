using System.Threading.Tasks;
using BetService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BetService.Pages.Admin.Event
{
    public class DetailsModel : PageModel
    {
        private readonly BetDbContext _context;

        public DetailsModel(BetDbContext context)
        {
            _context = context;
        }

        public Models.Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Event.FirstOrDefaultAsync(m => m.Id == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
