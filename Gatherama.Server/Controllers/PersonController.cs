using Microsoft.AspNetCore.Mvc;
using Gatherama.Server.Models;
using Gatherama.Server.Services;
using Gatherama.Shared;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.AspNetCore.Authorization;

namespace Gatherama.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly GatheramaDbContext _context;

        public PersonController(GatheramaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetPersons()
        {
            var persons = await _context.Persons.Find(_ => true).ToListAsync();
            return Ok(persons);
        }
        // GET: api/items/1
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetPerson(string id)
        {
            var item = await _context.Persons.Find<Person>(i => i.Id == id).FirstOrDefaultAsync();
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        // POST: api/items
        [HttpPost]
        public async Task<ActionResult<PersonDto>> PostPerson(Person person)
        {
            await _context.Persons.InsertOneAsync(person);
            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }
        // PUT: api/items/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(string id, Person person)
        {
            var updateResult = await _context.Persons.ReplaceOneAsync(t => t.Id == id, person);

            if (updateResult.MatchedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
        // DELETE: api/items/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(string id)
        {
            var deleteResult = await _context.Persons.DeleteOneAsync(i => i.Id == id);

            if (deleteResult.DeletedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
