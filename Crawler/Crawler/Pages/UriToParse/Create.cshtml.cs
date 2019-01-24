using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Crawler.Models;
using Crawler.Models.Entity;

namespace Crawler.Pages.UriToParse
{
    public class CreateModel : PageModel
    {
        private readonly Crawler.Models.ApplicationDbContext _context;

        public CreateModel(Crawler.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UriBetsToParse UriBetsToParse { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UrisBetsToParse.Add(UriBetsToParse);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}