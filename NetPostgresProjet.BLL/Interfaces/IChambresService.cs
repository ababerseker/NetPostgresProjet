using NetPostgresProjet.BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetPostgresProjet.BLL.Interfaces
{
    public interface IChambresService
    {
        Task<ChambresDto> GetByIdAsync(int id);
        Task<IEnumerable<ChambresDto>> GetAllAsync();
        Task<IEnumerable<ChambresDto>> GetChambresDisponiblesAsync();
        Task<ChambresDto> CreateAsync(ChambresDto chambresDto);
        Task<ChambresDto> UpdateAsync(int id, ChambresDto chambresDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> NumeroExistsAsync(string numero, int? excludeId = null);
    }
}
