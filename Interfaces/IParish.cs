using crudNet.DTOs;

namespace crudNet.Interfaces
{
    public interface IParish
    {
        Task<List<ParishDTO>> GetParishesAsync(int munId = 0, string codPar = null);
    }
}
