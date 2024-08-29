using crudNet.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crudNet.Interfaces
{
    public interface IElectionResultService
    {
        Task ProcessCsvAsync(IFormFile formFile);
        Task SaveElectionResultAsync(ElectionResult result);
        Task<List<ElectionResult>> GetElectionResultsAsync();
    }
}

