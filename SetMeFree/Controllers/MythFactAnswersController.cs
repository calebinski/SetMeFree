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
    public class MythFactAnswersController : ControllerBase
    {
        private readonly DataContext _context;

        public MythFactAnswersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MythFactAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MythFactAnswer>>> GetMythFactAnswers()
        {
            return await _context.MythFactAnswers.ToListAsync();
        }

        // GET: api/MythFactAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MythFactAnswer>> GetMythFactAnswer(int id)
        {
            var mythFactAnswer = await _context.MythFactAnswers.FindAsync(id);

            if (mythFactAnswer == null)
            {
                return NotFound();
            }

            return mythFactAnswer;
        }

        // PUT: api/MythFactAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMythFactAnswer(int id, MythFactAnswer mythFactAnswer)
        {
            if (id != mythFactAnswer.ID)
            {
                return BadRequest();
            }

            _context.Entry(mythFactAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MythFactAnswerExists(id))
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

        // POST: api/MythFactAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MythFactAnswer>> PostMythFactAnswer(MythFactAnswer mythFactAnswer)
        {
            _context.MythFactAnswers.Add(mythFactAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMythFactAnswer", new { id = mythFactAnswer.ID }, mythFactAnswer);
        }

        // DELETE: api/MythFactAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMythFactAnswer(int id)
        {
            var mythFactAnswer = await _context.MythFactAnswers.FindAsync(id);
            if (mythFactAnswer == null)
            {
                return NotFound();
            }

            _context.MythFactAnswers.Remove(mythFactAnswer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MythFactAnswerExists(int id)
        {
            return _context.MythFactAnswers.Any(e => e.ID == id);
        }
    }
}
