using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BetService.Models;

namespace BetService.Pages.Admin.BetCategory
{
    public class IndexModel : PageModel
    {
        private readonly BetDbContext _context;

        public IndexModel(BetDbContext context)
        {
            _context = context;
        }

        public IList<Models.BetCategory> BetCategory { get;set; }

        public async Task OnGetAsync()
        {
            BetCategory = await _context.BetCategory.ToListAsync();
        }
    }
}
