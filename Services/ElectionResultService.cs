using crudNet.Data;
using crudNet.Interfaces;
using crudNet.Models;
using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace crudNet.Services
{
    public class ElectionResultService : IElectionResultService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICsvProcessor _csvProcessor;

        public ElectionResultService(ApplicationDbContext context, ICsvProcessor csvProcessor)
        {
            _context = context;
            _csvProcessor = csvProcessor;
        }

        public async Task ProcessCsv(IFormFile formFile)
        {
            var results = await _csvProcessor.ProcessCsvAsync(formFile);
            foreach (var result in results)
            {
                await SaveElectionResultAsync(result);
            }
        }

        public async Task ProcessCsvAsync(IFormFile formFile)
        {
            if (formFile.Length > 0)
            {
                using (var reader = new StreamReader(formFile.OpenReadStream()))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null, // Ignorar la validación de encabezados
                    MissingFieldFound = null // Ignorar campos faltantes
                }))
                {
                    var records = csv.GetRecords<ElectionResult>().ToList();

                    // Asignar un valor único para Id
                    for (int i = 0; i < records.Count; i++)
                    {
                        records[i].Id = i + 1; // O cualquier lógica para generar IDs únicos
                    }

                    // Procesa los registros aquí
                    foreach (var record in records)
                    {
                        await SaveElectionResultAsync(record);
                    }
                }
            }
        }
        public async Task SaveElectionResultAsync(ElectionResult result)
        {
            await _context.ElectionResults.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ElectionResult>> GetElectionResultsAsync()
        {
            return await _context.ElectionResults
                .ToListAsync();
        }
    }
}
