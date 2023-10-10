using Gatherama.Server.Models;
using Gatherama.Shared;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;

namespace Gatherama.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceController : ControllerBase
    {
        private readonly GatheramaDbContext _context;
        public PlaceController(GatheramaDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaceDto>>> GetPlaces()
        {
            var places = await _context.Place.Find(_ => true).ToListAsync();
            return Ok(places);
        }
        // GET: api/items/1
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaceDto>> GetPlace(string id)
        {
            var place = await _context.Place.Find<Place>(i => i.Id == id).FirstOrDefaultAsync();
            if (place == null)
            {
                return NotFound();
            }
            return Ok(place);
        }
        // POST: api/items
        [HttpPost]
        public async Task<ActionResult<PlaceDto>> PostPlace(Place place)
        {
            await _context.Place.InsertOneAsync(place);
            return CreatedAtAction(nameof(GetPlace), new { id = place.Id }, place);
        }
        // PUT: api/items/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlace(string id, Place place)
        {
            var updateResult = await _context.Place.ReplaceOneAsync(t => t.Id == id, place);

            if (updateResult.MatchedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
        // DELETE: api/items/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlace(string id)
        {
            var deleteResult = await _context.Place.DeleteOneAsync(i => i.Id == id);

            if (deleteResult.DeletedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
