using crudNet.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crudNet.Interfaces
{
    public interface IMunicipality
    {
        Task<List<MunicipalityDTO>> GetMunicipalitiesAsync(int codEdo = 0, string codMun = null);
    }
}
