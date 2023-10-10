using Gatherama.Server.Models;
using Gatherama.Shared;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;

namespace Gatherama.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaController : ControllerBase
    {
        private readonly GatheramaDbContext _context;
        public MediaController(GatheramaDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaDto>>> GetMedias()
        {
            var media = await _context.Findings.Find(_ => true).ToListAsync();
            return Ok(media);
        }
        // GET: api/items/1
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaDto>> GetMedia(string id)
        {
            var media = await _context.Media.Find<Media>(i => i.Id == id).FirstOrDefaultAsync();
            if (media == null)
            {
                return NotFound();
            }
            return Ok(media);
        }
        // POST: api/items
        [HttpPost]
        public async Task<ActionResult<MediaDto>> PostMedia(Media media)
        {
            await _context.Media.InsertOneAsync(media);
            return CreatedAtAction(nameof(GetMedia), new { id = media.Id }, media);
        }
        // PUT: api/items/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedia(string id, Media media)
        {
            var updateResult = await _context.Media.ReplaceOneAsync(t => t.Id == id, media);

            if (updateResult.MatchedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
        // DELETE: api/items/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedia(string id)
        {
            var deleteResult = await _context.Media.DeleteOneAsync(i => i.Id == id);

            if (deleteResult.DeletedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
