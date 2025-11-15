using NetPostgresProjet.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetPostgresProjet.DAL.Interfaces
{
    public interface IHospitalisationRepository : IRepository<Hospitalisations>
    {
        Task<IEnumerable<Hospitalisations>> GetByPatientIdAsync(int patientId);
        Task<IEnumerable<Hospitalisations>> GetHospitalisationsEnCoursAsync();
        Task<Hospitalisations> GetActiveByPatientIdAsync(int patientId);
    }
}
