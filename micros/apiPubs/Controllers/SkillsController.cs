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
    public class SkillsController : ControllerBase
    {
        private readonly cvdbContext _context;

        public SkillsController(cvdbContext context)
        {
            _context = context;
        }

        // GET: api/Skills
        [HttpGet]
        public IEnumerable<Skills> GetSkills()
        {
            return _context.Skills;
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkills([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skills = await _context.Skills.FindAsync(id);

            if (skills == null)
            {
                return NotFound();
            }

            return Ok(skills);
        }

        // PUT: api/Skills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkills([FromRoute] int id, [FromBody] Skills skills)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skills.SkillId)
            {
                return BadRequest();
            }

            _context.Entry(skills).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillsExists(id))
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

        // POST: api/Skills
        [HttpPost]
        public async Task<IActionResult> PostSkills([FromBody] Skills skills)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Skills.Add(skills);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkills", new { id = skills.SkillId }, skills);
        }

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkills([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var skills = await _context.Skills.FindAsync(id);
            if (skills == null)
            {
                return NotFound();
            }

            _context.Skills.Remove(skills);
            await _context.SaveChangesAsync();

            return Ok(skills);
        }

        private bool SkillsExists(int id)
        {
            return _context.Skills.Any(e => e.SkillId == id);
        }
    }
}