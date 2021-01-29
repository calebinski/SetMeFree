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
    public class GroomingStepAnswersController : ControllerBase
    {
        private readonly DataContext _context;

        public GroomingStepAnswersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GroomingStepAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroomingStepAnswer>>> GetGroomingStepAnswers()
        {
            return await _context.GroomingStepAnswers.ToListAsync();
        }

        // GET: api/GroomingStepAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroomingStepAnswer>> GetGroomingStepAnswer(int id)
        {
            var groomingStepAnswer = await _context.GroomingStepAnswers.FindAsync(id);

            if (groomingStepAnswer == null)
            {
                return NotFound();
            }

            return groomingStepAnswer;
        }

        // PUT: api/GroomingStepAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroomingStepAnswer(int id, GroomingStepAnswer groomingStepAnswer)
        {
            if (id != groomingStepAnswer.ID)
            {
                return BadRequest();
            }

            _context.Entry(groomingStepAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroomingStepAnswerExists(id))
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

        // POST: api/GroomingStepAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroomingStepAnswer>> PostGroomingStepAnswer(GroomingStepAnswer groomingStepAnswer)
        {
            _context.GroomingStepAnswers.Add(groomingStepAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroomingStepAnswer", new { id = groomingStepAnswer.ID }, groomingStepAnswer);
        }

        // DELETE: api/GroomingStepAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroomingStepAnswer(int id)
        {
            var groomingStepAnswer = await _context.GroomingStepAnswers.FindAsync(id);
            if (groomingStepAnswer == null)
            {
                return NotFound();
            }

            _context.GroomingStepAnswers.Remove(groomingStepAnswer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroomingStepAnswerExists(int id)
        {
            return _context.GroomingStepAnswers.Any(e => e.ID == id);
        }
    }
}
