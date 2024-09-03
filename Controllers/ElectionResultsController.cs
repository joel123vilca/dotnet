using crudNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace crudNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElectionResultsController : ControllerBase
    {
        private readonly ElectionDbContext _context;

        public ElectionResultsController(ElectionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElectionResult>>> GetElectionResults()
        {
            return await _context.ElectionResults.ToListAsync();
        }

       
    }
}
