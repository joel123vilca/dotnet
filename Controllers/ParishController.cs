using Microsoft.AspNetCore.Mvc;
using crudNet.Interfaces;
using crudNet.Services;
using crudNet.DTOs;

namespace crudNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParishController : ControllerBase
    {
        private readonly IParish _parishService;

        public ParishController(IParish parishService)
        {
            _parishService = parishService;
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<ParishDTO>>> GetParishByFilter([FromQuery] int munId, [FromQuery] string parishCode)
        {
            var parish = await _parishService.GetParishesAsync(munId, parishCode);
            return Ok(parish);
        }
    }
}
