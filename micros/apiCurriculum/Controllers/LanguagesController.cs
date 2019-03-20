using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiCurriculum.Models;

namespace apiCurriculum.Controllers
{
    [Route("api-cv/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly cvdbContext _context;

        public LanguagesController(cvdbContext context)
        {
            _context = context;
        }

        // GET: api/Languages
        [HttpGet]
        public IEnumerable<Languages> GetLanguages()
        {
            return _context.Languages;
        }

        // GET: api/Languages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguages([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var languages = await _context.Languages.FindAsync(id);

            if (languages == null)
            {
                return NotFound();
            }

            return Ok(languages);
        }

        // PUT: api/Languages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguages([FromRoute] int id, [FromBody] Languages languages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != languages.LanguageId)
            {
                return BadRequest();
            }

            _context.Entry(languages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguagesExists(id))
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

        // POST: api/Languages
        [HttpPost]
        public async Task<IActionResult> PostLanguages([FromBody] Languages languages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Languages.Add(languages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLanguages", new { id = languages.LanguageId }, languages);
        }

        // DELETE: api/Languages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguages([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var languages = await _context.Languages.FindAsync(id);
            if (languages == null)
            {
                return NotFound();
            }

            _context.Languages.Remove(languages);
            await _context.SaveChangesAsync();

            return Ok(languages);
        }

        private bool LanguagesExists(int id)
        {
            return _context.Languages.Any(e => e.LanguageId == id);
        }
    }
}