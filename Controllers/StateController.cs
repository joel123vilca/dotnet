using crudNet.Services;
using crudNet.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace crudNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IState _stateService;

        public StateController(IState stateService)
        {
            _stateService = stateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStates([FromQuery] string codEdo)
        {
            var states = await _stateService.GetStatesAsync(codEdo);
            return Ok(states);
        }
    }
}
