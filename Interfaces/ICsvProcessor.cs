using crudNet.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crudNet.Interfaces
{
    public interface ICsvProcessor
    {
        
        Task<List<ElectionResult>> ProcessCsvAsync(IFormFile formFile);
    }
}