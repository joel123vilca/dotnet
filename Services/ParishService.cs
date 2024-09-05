using crudNet.DTOs;
using crudNet.Models;
using crudNet.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crudNet.Services
{
    public class ParishService : IParish
    {
        private readonly ElectionDbContext _context;

        public ParishService(ElectionDbContext context)
        {
            _context = context;
        }

        public async Task<List<ParishDTO>> GetParishesAsync(int munId = 0, string codPar = null)
        {
            var query = _context.Parishes.AsQueryable();

            if (munId != 0)
            {
                query = query.Where(p => p.MunicipalityId == munId);
            }

            if (!string.IsNullOrEmpty(codPar))
            {
                query = query.Where(p => p.CodPar == codPar);
            }

            return await query
                .Select(p => new ParishDTO
                {
                    CodPar = p.CodPar,
                    Name = p.Name,
                })
                .ToListAsync();
        }
    }
}
