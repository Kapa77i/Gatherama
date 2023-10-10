using Gatherama.Server.Models;
using Gatherama.Shared;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;

namespace Gatherama.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpeciesController : ControllerBase
    {
        private readonly GatheramaDbContext _context;
        public SpeciesController(GatheramaDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpeciesDto>>> GetSpecies()
        {
            var species = await _context.Species.Find(_ => true).ToListAsync();
            return Ok(species);
        }
        // GET: api/items/1
        [HttpGet("{id}")]
        public async Task<ActionResult<SpeciesDto>> GetSpeciment(string id)
        {
            var speciment = await _context.Species.Find<Species>(i => i.Id == id).FirstOrDefaultAsync();
            if (speciment == null)
            {
                return NotFound();
            }
            return Ok(speciment);
        }
        // POST: api/items
        [HttpPost]
        public async Task<ActionResult<SpeciesDto>> PostSpeciment(Species speciment)
        {
            await _context.Species.InsertOneAsync(speciment);
            return CreatedAtAction(nameof(GetSpeciment), new { id = speciment.Id }, speciment);
        }
        // PUT: api/items/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpeciment(string id, Species speciment)
        {
            var updateResult = await _context.Species.ReplaceOneAsync(t => t.Id == id, speciment);

            if (updateResult.MatchedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
        // DELETE: api/items/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpeciment(string id)
        {
            var deleteResult = await _context.Species.DeleteOneAsync(i => i.Id == id);

            if (deleteResult.DeletedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
