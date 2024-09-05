using crudNet.DTOs;
using crudNet.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace crudNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityController : ControllerBase
    {
        private readonly IMunicipality _municipalityService;

        public MunicipalityController(IMunicipality municipalityService)
        {
            _municipalityService = municipalityService;
        }

        
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<MunicipalityDTO>>> GetMunicipalitiesByFilter([FromQuery] int stateCode, [FromQuery] string municipalityCode)
        {
            var municipalities = await _municipalityService.GetMunicipalitiesAsync(stateCode, municipalityCode);
            return Ok(municipalities);
        }
    }
}
