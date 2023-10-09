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
        private readonly GatheramaDbContext _context;

        public PersonController(GatheramaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Persons.Find(_ => true).ToList());
        }
/*                public async Task<List<PersonDto>> Get() =>
                    await _personsService.GetAsync();*/
    }
}
