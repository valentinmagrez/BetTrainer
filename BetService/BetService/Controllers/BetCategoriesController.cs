using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BetService.Models;

namespace BetService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetCategoriesController : ControllerBase
    {
        private readonly BetDbContext _context;

        public BetCategoriesController(BetDbContext context)
        {
            _context = context;
        }

        // GET: api/BetCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BetCategory>>> GetBetCategory()
        {
            return await _context.BetCategory.ToListAsync();
        }

        // GET: api/BetCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BetCategory>> GetBetCategory(Guid id)
        {
            var betCategory = await _context.BetCategory.FindAsync(id);

            if (betCategory == null)
            {
                return NotFound();
            }

            return betCategory;
        }

        // PUT: api/BetCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBetCategory(Guid id, BetCategory betCategory)
        {
            if (id != betCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(betCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BetCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BetCategories
        [HttpPost]
        public async Task<ActionResult<BetCategory>> PostBetCategory(BetCategory betCategory)
        {
            _context.BetCategory.Add(betCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBetCategory", new { id = betCategory.Id }, betCategory);
        }

        // DELETE: api/BetCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BetCategory>> DeleteBetCategory(Guid id)
        {
            var betCategory = await _context.BetCategory.FindAsync(id);
            if (betCategory == null)
            {
                return NotFound();
            }

            _context.BetCategory.Remove(betCategory);
            await _context.SaveChangesAsync();

            return betCategory;
        }

        private bool BetCategoryExists(Guid id)
        {
            return _context.BetCategory.Any(e => e.Id == id);
        }
    }
}
