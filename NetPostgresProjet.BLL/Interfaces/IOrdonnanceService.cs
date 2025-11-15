using NetPostgresProjet.BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetPostgresProjet.BLL.Interfaces
{
    public interface IOrdonnanceService
    {
        Task<OrdonnanceDto> GetByIdAsync(int id);
        Task<IEnumerable<OrdonnanceDto>> GetAllAsync();
        Task<IEnumerable<OrdonnanceDto>> GetByPatientIdAsync(int patientId);
        Task<IEnumerable<OrdonnanceDto>> GetByMedecinIdAsync(int medecinId);
        Task<OrdonnanceDto> CreateAsync(OrdonnanceDto ordonnanceDto);
        Task<OrdonnanceDto> UpdateAsync(int id, OrdonnanceDto ordonnanceDto);
        Task<bool> DeleteAsync(int id);
    }
}
