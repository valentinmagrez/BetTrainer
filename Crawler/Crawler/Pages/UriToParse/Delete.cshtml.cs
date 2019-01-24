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
    public class DeleteModel : PageModel
    {
        private readonly Crawler.Models.ApplicationDbContext _context;

        public DeleteModel(Crawler.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UriBetsToParse UriBetsToParse { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UriBetsToParse = await _context.UrisBetsToParse.FirstOrDefaultAsync(m => m.Id == id);

            if (UriBetsToParse == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UriBetsToParse = await _context.UrisBetsToParse.FindAsync(id);

            if (UriBetsToParse != null)
            {
                _context.UrisBetsToParse.Remove(UriBetsToParse);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
