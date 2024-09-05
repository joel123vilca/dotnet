using crudNet.DTOs;
using crudNet.Models;
using crudNet.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crudNet.Services
{
    public class StateService : IState
    {
        private readonly ElectionDbContext _context;

        public StateService(ElectionDbContext context)
        {
            _context = context;
        }

        public async Task<List<StateDTO>> GetStatesAsync(string codEdo = null)
        {
            var query = _context.States.AsQueryable();

            if (!string.IsNullOrEmpty(codEdo))
            {
                query = query.Where(s => s.CodEdo == codEdo);
            }

            return await query
                .Select(s => new StateDTO
                {
                    CodEdo = s.CodEdo,
                    Name = s.Name
                })
                .ToListAsync();
        }
    }
}
