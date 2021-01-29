using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SetMeFree.Data;
using SetMeFree.Models;

namespace SetMeFree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuessWhoesController : ControllerBase
    {
        private readonly DataContext _context;

        public GuessWhoesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GuessWhoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuessWho>>> GetGuessWho()
        {
            return await _context.GuessWho.ToListAsync();
        }

        // GET: api/GuessWhoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuessWho>> GetGuessWho(int id)
        {
            var guessWho = await _context.GuessWho.FindAsync(id);

            if (guessWho == null)
            {
                return NotFound();
            }

            return guessWho;
        }

        // PUT: api/GuessWhoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuessWho(int id, GuessWho guessWho)
        {
            if (id != guessWho.ID)
            {
                return BadRequest();
            }

            _context.Entry(guessWho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuessWhoExists(id))
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

        // POST: api/GuessWhoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GuessWho>> PostGuessWho(GuessWho guessWho)
        {
            _context.GuessWho.Add(guessWho);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuessWho", new { id = guessWho.ID }, guessWho);
        }

        // DELETE: api/GuessWhoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuessWho(int id)
        {
            var guessWho = await _context.GuessWho.FindAsync(id);
            if (guessWho == null)
            {
                return NotFound();
            }

            _context.GuessWho.Remove(guessWho);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GuessWhoExists(int id)
        {
            return _context.GuessWho.Any(e => e.ID == id);
        }
    }
}
