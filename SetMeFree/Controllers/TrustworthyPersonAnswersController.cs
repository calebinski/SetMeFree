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
    public class TrustworthyPersonAnswersController : ControllerBase
    {
        private readonly DataContext _context;

        public TrustworthyPersonAnswersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TrustworthyPersonAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrustworthyPersonAnswer>>> GetTrustworthyPersonAnswers()
        {
            return await _context.TrustworthyPersonAnswers.ToListAsync();
        }

        // GET: api/TrustworthyPersonAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrustworthyPersonAnswer>> GetTrustworthyPersonAnswer(int id)
        {
            var trustworthyPersonAnswer = await _context.TrustworthyPersonAnswers.FindAsync(id);

            if (trustworthyPersonAnswer == null)
            {
                return NotFound();
            }

            return trustworthyPersonAnswer;
        }

        // PUT: api/TrustworthyPersonAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrustworthyPersonAnswer(int id, TrustworthyPersonAnswer trustworthyPersonAnswer)
        {
            if (id != trustworthyPersonAnswer.ID)
            {
                return BadRequest();
            }

            _context.Entry(trustworthyPersonAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrustworthyPersonAnswerExists(id))
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

        // POST: api/TrustworthyPersonAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrustworthyPersonAnswer>> PostTrustworthyPersonAnswer(TrustworthyPersonAnswer trustworthyPersonAnswer)
        {
            _context.TrustworthyPersonAnswers.Add(trustworthyPersonAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrustworthyPersonAnswer", new { id = trustworthyPersonAnswer.ID }, trustworthyPersonAnswer);
        }

        // DELETE: api/TrustworthyPersonAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrustworthyPersonAnswer(int id)
        {
            var trustworthyPersonAnswer = await _context.TrustworthyPersonAnswers.FindAsync(id);
            if (trustworthyPersonAnswer == null)
            {
                return NotFound();
            }

            _context.TrustworthyPersonAnswers.Remove(trustworthyPersonAnswer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrustworthyPersonAnswerExists(int id)
        {
            return _context.TrustworthyPersonAnswers.Any(e => e.ID == id);
        }
    }
}
