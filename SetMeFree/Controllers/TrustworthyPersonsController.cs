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
    public class TrustworthyPersonsController : ControllerBase
    {
        private readonly DataContext _context;

        public TrustworthyPersonsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TrustworthyPersons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrustworthyPerson>>> GetTrustworthyPerson()
        {
            return await _context.TrustworthyPerson.ToListAsync();
        }

        // GET: api/TrustworthyPersons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrustworthyPerson>> GetTrustworthyPerson(int id)
        {
            var trustworthyPerson = await _context.TrustworthyPerson.FindAsync(id);

            if (trustworthyPerson == null)
            {
                return NotFound();
            }

            return trustworthyPerson;
        }

        // PUT: api/TrustworthyPersons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrustworthyPerson(int id, TrustworthyPerson trustworthyPerson)
        {
            if (id != trustworthyPerson.ID)
            {
                return BadRequest();
            }

            _context.Entry(trustworthyPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrustworthyPersonExists(id))
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

        // POST: api/TrustworthyPersons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrustworthyPerson>> PostTrustworthyPerson(TrustworthyPerson trustworthyPerson)
        {
            _context.TrustworthyPerson.Add(trustworthyPerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrustworthyPerson", new { id = trustworthyPerson.ID }, trustworthyPerson);
        }

        // DELETE: api/TrustworthyPersons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrustworthyPerson(int id)
        {
            var trustworthyPerson = await _context.TrustworthyPerson.FindAsync(id);
            if (trustworthyPerson == null)
            {
                return NotFound();
            }

            _context.TrustworthyPerson.Remove(trustworthyPerson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrustworthyPersonExists(int id)
        {
            return _context.TrustworthyPerson.Any(e => e.ID == id);
        }
    }
}
