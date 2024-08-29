using CsvHelper;
using crudNet.Models;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using crudNet.Interfaces;

namespace crudNet.Services
{
    public class CsvProcessor : ICsvProcessor
    {
        public async Task<List<ElectionResult>> ProcessCsvAsync(IFormFile formFile)
        {
            var results = new List<ElectionResult>();

            using (var stream = formFile.OpenReadStream())
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                while (await csv.ReadAsync())
                {
                    var result = csv.GetRecord<ElectionResult>();
                    results.Add(result);
                }
            }

            return results;
        }
    }
}
