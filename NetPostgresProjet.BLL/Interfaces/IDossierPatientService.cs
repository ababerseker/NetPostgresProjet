using NetPostgresProjet.BLL.DTOs;
using System.Threading.Tasks;

namespace NetPostgresProjet.BLL.Interfaces
{
    public interface IDossierPatientService
    {
        Task<DossierPatientDto> GetByIdAsync(int id);
        Task<DossierPatientDto> GetByPatientIdAsync(int patientId);
        Task<DossierPatientDto> CreateAsync(DossierPatientDto dossierDto);
        Task<DossierPatientDto> UpdateAsync(int id, DossierPatientDto dossierDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> PatientHasDossierAsync(int patientId);
    }
}
