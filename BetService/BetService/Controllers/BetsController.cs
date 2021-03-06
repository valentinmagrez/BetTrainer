﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BetService.Models;

namespace BetService.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class BetsController : ControllerBase
    {
        private readonly BetDbContext _context;

        public BetsController(BetDbContext context)
        {
            _context = context;
        }

        // GET: api/bets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bet>>> GetBetItems()
        {
            return await _context.BetItems.ToListAsync();
        }

        // GET: api/bets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bet>> GetBet(Guid id)
        {
            var bet = await _context.BetItems.FindAsync(id);

            if (bet == null)
            {
                return NotFound();
            }

            return bet;
        }

        // PUT: api/Bets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBet(Guid id, Bet bet)
        {
            if (id != bet.Id)
            {
                return BadRequest();
            }

            _context.Entry(bet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BetExists(id))
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

        // POST: api/Bets
        [HttpPost]
        public async Task<ActionResult<Bet>> PostBet(Bet bet)
        {
            _context.BetItems.Add(bet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBet", new { id = bet.Id }, bet);
        }

        // DELETE: api/Bets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bet>> DeleteBet(Guid id)
        {
            var bet = await _context.BetItems.FindAsync(id);
            if (bet == null)
            {
                return NotFound();
            }

            _context.BetItems.Remove(bet);
            await _context.SaveChangesAsync();

            return bet;
        }

        private bool BetExists(Guid id)
        {
            return _context.BetItems.Any(e => e.Id == id);
        }
    }
}
