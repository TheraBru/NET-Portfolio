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
    public class FrameworkController : ControllerBase
    {
        private readonly PortfolioDbContext _context;

        public FrameworkController(PortfolioDbContext context)
        {
            _context = context;
        }

        // GET: api/Framework
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Framework>>> GetFramework()
        {
            return await _context.Framework.ToListAsync();
        }

        // GET: api/Framework/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Framework>> GetFramework(int id)
        {
            var framework = await _context.Framework.FindAsync(id);

            if (framework == null)
            {
                return NotFound();
            }

            return framework;
        }

        // PUT: api/Framework/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFramework(int id, Framework framework)
        {
            if (id != framework.frameworkId)
            {
                return BadRequest();
            }

            _context.Entry(framework).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FrameworkExists(id))
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

        // POST: api/Framework
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Framework>> PostFramework(Framework framework)
        {
            _context.Framework.Add(framework);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFramework", new { id = framework.frameworkId }, framework);
        }

        // DELETE: api/Framework/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFramework(int id)
        {
            var framework = await _context.Framework.FindAsync(id);
            if (framework == null)
            {
                return NotFound();
            }

            _context.Framework.Remove(framework);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FrameworkExists(int id)
        {
            return _context.Framework.Any(e => e.frameworkId == id);
        }
    }
}
