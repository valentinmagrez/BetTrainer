using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crawler.Models;
using Crawler.Models.Entity;

namespace Crawler.Pages.UriToParse
{
    public class IndexModel : PageModel
    {
        private readonly Crawler.Models.ApplicationDbContext _context;

        public IndexModel(Crawler.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UriBetsToParse> UriBetsToParse { get;set; }

        public async Task OnGetAsync()
        {
            UriBetsToParse = await _context.UrisBetsToParse.ToListAsync();
        }
    }
}
