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
    public class GuessWhoAnswersController : ControllerBase
    {
        private readonly DataContext _context;

        public GuessWhoAnswersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GuessWhoAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuessWhoAnswer>>> GetGuessWhoAnswers()
        {
            return await _context.GuessWhoAnswers.ToListAsync();
        }

        // GET: api/GuessWhoAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuessWhoAnswer>> GetGuessWhoAnswer(int id)
        {
            var guessWhoAnswer = await _context.GuessWhoAnswers.FindAsync(id);

            if (guessWhoAnswer == null)
            {
                return NotFound();
            }

            return guessWhoAnswer;
        }

        // PUT: api/GuessWhoAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuessWhoAnswer(int id, GuessWhoAnswer guessWhoAnswer)
        {
            if (id != guessWhoAnswer.ID)
            {
                return BadRequest();
            }

            _context.Entry(guessWhoAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuessWhoAnswerExists(id))
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

        // POST: api/GuessWhoAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GuessWhoAnswer>> PostGuessWhoAnswer(GuessWhoAnswer guessWhoAnswer)
        {
            _context.GuessWhoAnswers.Add(guessWhoAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuessWhoAnswer", new { id = guessWhoAnswer.ID }, guessWhoAnswer);
        }

        // DELETE: api/GuessWhoAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuessWhoAnswer(int id)
        {
            var guessWhoAnswer = await _context.GuessWhoAnswers.FindAsync(id);
            if (guessWhoAnswer == null)
            {
                return NotFound();
            }

            _context.GuessWhoAnswers.Remove(guessWhoAnswer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GuessWhoAnswerExists(int id)
        {
            return _context.GuessWhoAnswers.Any(e => e.ID == id);
        }
    }
}
