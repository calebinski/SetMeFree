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
    public class GroomingStepsController : ControllerBase
    {
        private readonly DataContext _context;

        public GroomingStepsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GroomingSteps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroomingSteps>>> GetGroomingSteps()
        {
            return await _context.GroomingSteps.ToListAsync();
        }

        // GET: api/GroomingSteps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroomingSteps>> GetGroomingSteps(int id)
        {
            var groomingSteps = await _context.GroomingSteps.FindAsync(id);

            if (groomingSteps == null)
            {
                return NotFound();
            }

            return groomingSteps;
        }

        // PUT: api/GroomingSteps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroomingSteps(int id, GroomingSteps groomingSteps)
        {
            if (id != groomingSteps.ID)
            {
                return BadRequest();
            }

            _context.Entry(groomingSteps).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroomingStepsExists(id))
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

        // POST: api/GroomingSteps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroomingSteps>> PostGroomingSteps(GroomingSteps groomingSteps)
        {
            _context.GroomingSteps.Add(groomingSteps);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroomingSteps", new { id = groomingSteps.ID }, groomingSteps);
        }

        // DELETE: api/GroomingSteps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroomingSteps(int id)
        {
            var groomingSteps = await _context.GroomingSteps.FindAsync(id);
            if (groomingSteps == null)
            {
                return NotFound();
            }

            _context.GroomingSteps.Remove(groomingSteps);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroomingStepsExists(int id)
        {
            return _context.GroomingSteps.Any(e => e.ID == id);
        }
    }
}
