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
    public class ArticlesController : ControllerBase
    {
        private readonly cvdbContext _context;

        public ArticlesController(cvdbContext context)
        {
            _context = context;
        }

        // GET: api/Articles
        [HttpGet]
        public IEnumerable<Articles> GetArticles()
        {
            return _context.Articles;
        }

        // GET: api/Articles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticles([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var articles = await _context.Articles.FindAsync(id);

            if (articles == null)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        // PUT: api/Articles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticles([FromRoute] int id, [FromBody] Articles articles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != articles.ArticleId)
            {
                return BadRequest();
            }

            _context.Entry(articles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticlesExists(id))
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

        // POST: api/Articles
        [HttpPost]
        public async Task<IActionResult> PostArticles([FromBody] Articles articles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Articles.Add(articles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticles", new { id = articles.ArticleId }, articles);
        }

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticles([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var articles = await _context.Articles.FindAsync(id);
            if (articles == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(articles);
            await _context.SaveChangesAsync();

            return Ok(articles);
        }

        private bool ArticlesExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }
    }
}