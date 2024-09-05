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

        /// <summary>
        /// Obtiene una lista de estados. Puedes filtrar por código de estado.
        /// </summary>
        /// <param name="codEdo">Código del estado (opcional)</param>
        /// <returns>Lista de estados</returns>
        [HttpGet]
        public async Task<IActionResult> GetStates([FromQuery] string codEdo)
        {
            var states = await _stateService.GetStatesAsync(codEdo);
            return Ok(states);
        }
    }
}
