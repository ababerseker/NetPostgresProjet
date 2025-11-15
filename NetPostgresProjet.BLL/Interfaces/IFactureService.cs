using NetPostgresProjet.BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetPostgresProjet.BLL.Interfaces
{
    public interface IFactureService
    {
        Task<FactureDto> GetByIdAsync(int id);
        Task<IEnumerable<FactureDto>> GetAllAsync();
        Task<IEnumerable<FactureDto>> GetByPatientIdAsync(int patientId);
        Task<IEnumerable<FactureDto>> GetFacturesEnAttenteAsync();
        Task<FactureDto> CreateAsync(FactureDto factureDto);
        Task<FactureDto> UpdateAsync(int id, FactureDto factureDto);
        Task<bool> DeleteAsync(int id);
    }
}
