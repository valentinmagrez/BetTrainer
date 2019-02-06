using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BetService.Models;

namespace BetService.Pages.Admin.Event
{
    public class IndexModel : PageModel
    {
        private readonly BetDbContext _context;

        public IndexModel(BetDbContext context)
        {
            _context = context;
        }

        public IList<Models.Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Event.ToListAsync();
        }
    }
}
