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
    public class ConferencesController : ControllerBase
    {
        private readonly cvdbContext _context;

        public ConferencesController(cvdbContext context)
        {
            _context = context;
        }

        // GET: api/Conferences
        [HttpGet]
        public IEnumerable<Conferences> GetConferences()
        {
            return _context.Conferences;
        }

        // GET: api/Conferences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConferences([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conferences = await _context.Conferences.FindAsync(id);

            if (conferences == null)
            {
                return NotFound();
            }

            return Ok(conferences);
        }

        // PUT: api/Conferences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConferences([FromRoute] int id, [FromBody] Conferences conferences)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conferences.ConferenceId)
            {
                return BadRequest();
            }

            _context.Entry(conferences).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConferencesExists(id))
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

        // POST: api/Conferences
        [HttpPost]
        public async Task<IActionResult> PostConferences([FromBody] Conferences conferences)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Conferences.Add(conferences);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConferences", new { id = conferences.ConferenceId }, conferences);
        }

        // DELETE: api/Conferences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConferences([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conferences = await _context.Conferences.FindAsync(id);
            if (conferences == null)
            {
                return NotFound();
            }

            _context.Conferences.Remove(conferences);
            await _context.SaveChangesAsync();

            return Ok(conferences);
        }

        private bool ConferencesExists(int id)
        {
            return _context.Conferences.Any(e => e.ConferenceId == id);
        }
    }
}