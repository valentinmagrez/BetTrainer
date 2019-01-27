using System.Collections.Generic;
using System.Threading.Tasks;
using BetService.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BetService.Pages.Admin.Bet
{
    public class IndexModel : PageModel
    {
        private readonly BetDbContext _context;

        public IndexModel(BetDbContext context)
        {
            _context = context;
        }

        public IList<Models.Bet> Bet { get;set; }

        public async Task OnGetAsync()
        {
            Bet = await _context.BetItems.ToListAsync();
        }
    }
}
