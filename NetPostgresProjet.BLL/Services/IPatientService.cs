using NetPostgresProjet.BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetPostgresProjet.BLL.Services
{
    public interface IPatientService
    {
        Task<List<PatientDto>> GetAllPatientsAsync();
        Task<PatientDto?> GetPatientByIdAsync(int id);
        Task<PatientDto> CreatePatientAsync(PatientDto patientDto);
        Task UpdatePatientAsync(int id, PatientDto patientDto);
        Task DeletePatientAsync(int id);
    }
}
