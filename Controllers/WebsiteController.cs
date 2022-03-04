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
    public class WebsiteController : ControllerBase
    {
        private readonly PortfolioDbContext _context;

        public WebsiteController(PortfolioDbContext context)
        {
            _context = context;
        }

        // GET: api/Website
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Website>>> GetWebsite()
        {
            return await _context.Website.ToListAsync();
        }

        // GET: api/Website/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Website>> GetWebsite(int id)
        {
            var website = await _context.Website.FindAsync(id);

            if (website == null)
            {
                return NotFound();
            }

            return website;
        }

        // PUT: api/Website/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWebsite(int id, Website website)
        {
            if (id != website.websiteId)
            {
                return BadRequest();
            }

            _context.Entry(website).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebsiteExists(id))
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

        // POST: api/Website
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Website>> PostWebsite(Website website)
        {
            _context.Website.Add(website);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWebsite", new { id = website.websiteId }, website);
        }

        // DELETE: api/Website/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWebsite(int id)
        {
            var website = await _context.Website.FindAsync(id);
            if (website == null)
            {
                return NotFound();
            }

            _context.Website.Remove(website);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WebsiteExists(int id)
        {
            return _context.Website.Any(e => e.websiteId == id);
        }
    }
}
