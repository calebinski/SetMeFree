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
    public class MythFactsController : ControllerBase
    {
        private readonly DataContext _context;

        public MythFactsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MythFacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MythFact>>> GetMythFacts()
        {
            return await _context.MythFacts.ToListAsync();
        }

        // GET: api/MythFacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MythFact>> GetMythFact(int id)
        {
            var mythFact = await _context.MythFacts.FindAsync(id);

            if (mythFact == null)
            {
                return NotFound();
            }

            return mythFact;
        }

        // PUT: api/MythFacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMythFact(int id, MythFact mythFact)
        {
            if (id != mythFact.ID)
            {
                return BadRequest();
            }

            _context.Entry(mythFact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MythFactExists(id))
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

        // POST: api/MythFacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MythFact>> PostMythFact(MythFact mythFact)
        {
            _context.MythFacts.Add(mythFact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMythFact", new { id = mythFact.ID }, mythFact);
        }

        // DELETE: api/MythFacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMythFact(int id)
        {
            var mythFact = await _context.MythFacts.FindAsync(id);
            if (mythFact == null)
            {
                return NotFound();
            }

            _context.MythFacts.Remove(mythFact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MythFactExists(int id)
        {
            return _context.MythFacts.Any(e => e.ID == id);
        }
    }
}
