#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webbsida.Data;
using webbsida.Models;

namespace webbsida.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly PortfolioDbContext _context;

        public ProgramsController(PortfolioDbContext context)
        {
            _context = context;
        }

        // GET: api/Programs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programs>>> GetPrograms()
        {
            return await _context.Programs.ToListAsync();
        }

        // GET: api/Programs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Programs>> GetPrograms(int id)
        {
            var programs = await _context.Programs.FindAsync(id);

            if (programs == null)
            {
                return NotFound();
            }

            return programs;
        }

        // PUT: api/Programs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrograms(int id, Programs programs)
        {
            if (id != programs.programsId)
            {
                return BadRequest();
            }

            _context.Entry(programs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramsExists(id))
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

        // POST: api/Programs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Programs>> PostPrograms(Programs programs)
        {
            _context.Programs.Add(programs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrograms", new { id = programs.programsId }, programs);
        }

        // DELETE: api/Programs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrograms(int id)
        {
            var programs = await _context.Programs.FindAsync(id);
            if (programs == null)
            {
                return NotFound();
            }

            _context.Programs.Remove(programs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgramsExists(int id)
        {
            return _context.Programs.Any(e => e.programsId == id);
        }
    }
}
