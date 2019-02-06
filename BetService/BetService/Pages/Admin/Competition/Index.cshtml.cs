using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BetService.Models;

namespace BetService.Pages.Admin.Competition
{
    public class IndexModel : PageModel
    {
        private readonly BetDbContext _context;

        public IndexModel(BetDbContext context)
        {
            _context = context;
        }

        public IList<Models.Competition> Competition { get;set; }

        public async Task OnGetAsync()
        {
            Competition = await _context.Competition.ToListAsync();
        }
    }
}
