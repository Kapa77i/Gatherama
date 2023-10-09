using Gatherama.Server.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

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
        public IActionResult GetAll()
        {
            return Ok(_context.Place.Find(_ => true).ToList());
        }
    }
}
