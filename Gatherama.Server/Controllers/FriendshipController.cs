using Gatherama.Server.Models;
using Gatherama.Shared;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;

namespace Gatherama.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FriendshipController : ControllerBase
    {
        private readonly GatheramaDbContext _context;
        public FriendshipController(GatheramaDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendshipDto>>> GetFriendships()
        {
            var friendships = await _context.Friendships.Find(_ => true).ToListAsync();
            return Ok(friendships);
        }
        // GET: api/items/1
        [HttpGet("{id}")]
        public async Task<ActionResult<FriendshipDto>> GetFriendship(string id)
        {
            var friendship = await _context.Friendships.Find<Friendship>(i => i.Id == id).FirstOrDefaultAsync();
            if (friendship == null)
            {
                return NotFound();
            }
            return Ok(friendship);
        }
        // POST: api/items
        [HttpPost]
        public async Task<ActionResult<FriendshipDto>> PostFriendship(Friendship friendship)
        {
            await _context.Friendships.InsertOneAsync(friendship);
            return CreatedAtAction(nameof(GetFriendship), new { id = friendship.Id }, friendship);
        }
        // PUT: api/items/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFriendship(string id, Friendship friendship)
        {
            var updateResult = await _context.Friendships.ReplaceOneAsync(t => t.Id == id, friendship);

            if (updateResult.MatchedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
        // DELETE: api/items/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFriendship(string id)
        {
            var deleteResult = await _context.Friendships.DeleteOneAsync(i => i.Id == id);

            if (deleteResult.DeletedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
