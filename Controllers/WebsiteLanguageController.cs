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
    public class WebsiteLanguageController : ControllerBase
    {
        private readonly PortfolioDbContext _context;

        public WebsiteLanguageController(PortfolioDbContext context)
        {
            _context = context;
        }

        // GET: api/WebsiteLanguage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebsiteLanguage>>> GetWebsiteLanguage()
        {
            return await _context.WebsiteLanguage.ToListAsync();
        }

        // GET: api/WebsiteLanguage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WebsiteLanguage>> GetWebsiteLanguage(int id)
        {
            var websiteLanguage = await _context.WebsiteLanguage.FindAsync(id);

            if (websiteLanguage == null)
            {
                return NotFound();
            }

            return websiteLanguage;
        }

        // PUT: api/WebsiteLanguage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWebsiteLanguage(int id, WebsiteLanguage websiteLanguage)
        {
            if (id != websiteLanguage.websiteId)
            {
                return BadRequest();
            }

            _context.Entry(websiteLanguage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebsiteLanguageExists(id))
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

        // POST: api/WebsiteLanguage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WebsiteLanguage>> PostWebsiteLanguage(WebsiteLanguage websiteLanguage)
        {
            _context.WebsiteLanguage.Add(websiteLanguage);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WebsiteLanguageExists(websiteLanguage.websiteId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWebsiteLanguage", new { id = websiteLanguage.websiteId }, websiteLanguage);
        }

        // DELETE: api/WebsiteLanguage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWebsiteLanguage(int id)
        {
            var websiteLanguage = await _context.WebsiteLanguage.FindAsync(id);
            if (websiteLanguage == null)
            {
                return NotFound();
            }

            _context.WebsiteLanguage.Remove(websiteLanguage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WebsiteLanguageExists(int id)
        {
            return _context.WebsiteLanguage.Any(e => e.websiteId == id);
        }
    }
}
