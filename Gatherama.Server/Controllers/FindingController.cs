using Gatherama.Server.Models;
using Gatherama.Shared;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;

namespace Gatherama.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FindingController : ControllerBase
    {
        private readonly GatheramaDbContext _context;
        public FindingController(GatheramaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FindingDto>>> GetFindings()
        {
            var findings = await _context.Findings.Find(_ => true).ToListAsync();
            return Ok(findings);
        }

        // GET: api/items/1
        [HttpGet("{id}")]
        public async Task<ActionResult<FindingDto>> GetFinding(string id)
        {
            var finding = await _context.Findings.Find<Finding>(i => i.Id == id).FirstOrDefaultAsync();
            if (finding == null)
            {
                return NotFound();
            }
            return Ok(finding);
        }
        // POST: api/items
        [HttpPost]
        public async Task<ActionResult<FindingDto>> PostFinding(Finding finding)
        {
            await _context.Findings.InsertOneAsync(finding);
            return CreatedAtAction(nameof(GetFinding), new { id = finding.Id }, finding);
        }
        // PUT: api/items/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinding(string id, Finding finding)
        {
            var updateResult = await _context.Findings.ReplaceOneAsync(t => t.Id == id, finding);

            if (updateResult.MatchedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
        // DELETE: api/items/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinding(string id)
        {
            var deleteResult = await _context.Findings.DeleteOneAsync(i => i.Id == id);

            if (deleteResult.DeletedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
