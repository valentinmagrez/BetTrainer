using System;
using System.Threading.Tasks;
using BetService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BetService.Pages.Admin.Bet
{
    public class DetailsModel : PageModel
    {
        private readonly BetDbContext _context;

        public DetailsModel(BetDbContext context)
        {
            _context = context;
        }

        public Models.Bet Bet { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
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
    }
}
