using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudNet.DTOs;
using crudNet.Interfaces;
using crudNet.Models;

namespace crudNet.Services
{
    public class MunicipalityService : IMunicipality
    {
        private readonly ElectionDbContext _context;

        public MunicipalityService(ElectionDbContext context)
        {
            _context = context;
        }

        public async Task<List<MunicipalityDTO>> GetMunicipalitiesAsync(int codEdo = 0, string codMun = null)
        {
            var query = _context.Municipalities.AsQueryable();

            if (codEdo != 0)
            {
                query = query.Where(m => m.CodEdo == codEdo);
            }

            if (!string.IsNullOrEmpty(codMun))
            {
                query = query.Where(m => m.CodMun == codMun);
            }

            return await query
                .Select(m => new MunicipalityDTO
                {
                    CodMun = m.CodMun,
                    Name = m.Name,
                    Parishes = m.Parishes.Select(m => new ParishDTO
                    {
                        CodPar = m.CodPar,
                        Name = m.Name,
                    }).ToList()
                })
                .ToListAsync();
        }
    }
}
