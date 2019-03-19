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
    public class OwnersController : ControllerBase
    {
        private readonly cvdbContext _context;

        public OwnersController(cvdbContext context)
        {
            _context = context;
        }

        // GET: api/Owners
        [HttpGet]
        public IEnumerable<Owner> GetOwner()
        {
            return _context.Owner;
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwner([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var owner = await _context.Owner.FindAsync(id);

            if (owner == null)
            {
                return NotFound();
            }

            return Ok(owner);
        }

        // PUT: api/Owners/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner([FromRoute] int id, [FromBody] Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != owner.OwnerId)
            {
                return BadRequest();
            }

            _context.Entry(owner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(id))
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

        // POST: api/Owners
        [HttpPost]
        public async Task<IActionResult> PostOwner([FromBody] Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Owner.Add(owner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOwner", new { id = owner.OwnerId }, owner);
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var owner = await _context.Owner.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            _context.Owner.Remove(owner);
            await _context.SaveChangesAsync();

            return Ok(owner);
        }

        private bool OwnerExists(int id)
        {
            return _context.Owner.Any(e => e.OwnerId == id);
        }
    }
}