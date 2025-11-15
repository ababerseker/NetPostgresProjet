using NetPostgresProjet.BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetPostgresProjet.BLL.Interfaces
{
    public interface IHospitalisationService
    {
        Task<HospitalisationDto> GetByIdAsync(int id);
        Task<IEnumerable<HospitalisationDto>> GetAllAsync();
        Task<IEnumerable<HospitalisationDto>> GetByPatientIdAsync(int patientId);
        Task<IEnumerable<HospitalisationDto>> GetHospitalisationsEnCoursAsync();
        Task<HospitalisationDto> CreateAsync(HospitalisationDto hospitalisationDto);
        Task<HospitalisationDto> UpdateAsync(int id, HospitalisationDto hospitalisationDto);
        Task<bool> DeleteAsync(int id);
    }
}
