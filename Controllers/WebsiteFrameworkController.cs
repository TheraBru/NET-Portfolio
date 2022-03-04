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
    public class WebsiteFrameworkController : ControllerBase
    {
        private readonly PortfolioDbContext _context;

        public WebsiteFrameworkController(PortfolioDbContext context)
        {
            _context = context;
        }

        // GET: api/WebsiteFramework
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebsiteFramework>>> GetWebsiteFramework()
        {
            return await _context.WebsiteFramework.ToListAsync();
        }

        // GET: api/WebsiteFramework/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WebsiteFramework>> GetWebsiteFramework(int id)
        {
            var websiteFramework = await _context.WebsiteFramework.FindAsync(id);

            if (websiteFramework == null)
            {
                return NotFound();
            }

            return websiteFramework;
        }

        // PUT: api/WebsiteFramework/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWebsiteFramework(int id, WebsiteFramework websiteFramework)
        {
            if (id != websiteFramework.websiteId)
            {
                return BadRequest();
            }

            _context.Entry(websiteFramework).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebsiteFrameworkExists(id))
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

        // POST: api/WebsiteFramework
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WebsiteFramework>> PostWebsiteFramework(WebsiteFramework websiteFramework)
        {
            _context.WebsiteFramework.Add(websiteFramework);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WebsiteFrameworkExists(websiteFramework.websiteId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWebsiteFramework", new { id = websiteFramework.websiteId }, websiteFramework);
        }

        // DELETE: api/WebsiteFramework/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWebsiteFramework(int id)
        {
            var websiteFramework = await _context.WebsiteFramework.FindAsync(id);
            if (websiteFramework == null)
            {
                return NotFound();
            }

            _context.WebsiteFramework.Remove(websiteFramework);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WebsiteFrameworkExists(int id)
        {
            return _context.WebsiteFramework.Any(e => e.websiteId == id);
        }
    }
}
