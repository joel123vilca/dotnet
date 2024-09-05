using crudNet.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crudNet.Interfaces
{
    public interface IState
    {
        Task<List<StateDTO>> GetStatesAsync(string codEdo = null);
    }
}
