using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BetService.Models;

namespace BetService.Pages.Admin.Sport
{
    public class IndexModel : PageModel
    {
        private readonly BetDbContext _context;

        public IndexModel(BetDbContext context)
        {
            _context = context;
        }

        public IList<Models.Sport> Sport { get;set; }

        public async Task OnGetAsync()
        {
            Sport = await _context.Sport.ToListAsync();
        }
    }
}
