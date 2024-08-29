using Microsoft.AspNetCore.Mvc;
using crudNet.Services;
using crudNet.ViewModels;
using crudNet.Interfaces;

namespace crudNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElectionResultsController : ControllerBase
    {
        private readonly IElectionResultService _electionResultService;

        public ElectionResultsController(IElectionResultService electionResultService)
        {
            _electionResultService = electionResultService;
        }

        [HttpGet]
        public async Task<IActionResult> GetResults()
        {
            var results = await _electionResultService.GetElectionResultsAsync();
            return Ok(results);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                await _electionResultService.ProcessCsvAsync(file);
                return Ok("File processed successfully.");
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
