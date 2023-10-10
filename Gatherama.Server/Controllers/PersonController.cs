using Microsoft.AspNetCore.Mvc;
using Gatherama.Server.Models;
using Gatherama.Server.Services;
using Gatherama.Shared;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Gatherama.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly GatheramaDbContext _context;

        public PersonController(ILogger<PersonController> logger, GatheramaDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Persons.Find(_ => true).ToList());
        }
        [HttpPost]
        public async Task<IActionResult> GetPerson([FromBody] PersonDto person)
        {
            var filter = Builders<Person>.Filter.Eq(u => u.username, person.username) & Builders<Person>.Filter.Eq(u => u.password, person.password);
            var user = await _context.Persons.Find(filter).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }
            return Ok();
        }
/*                public async Task<List<PersonDto>> Get() =>
                    await _personsService.GetAsync();*/
    }
}
