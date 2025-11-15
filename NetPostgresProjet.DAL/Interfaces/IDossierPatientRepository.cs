using NetPostgresProjet.DAL.Models;
using System.Threading.Tasks;

namespace NetPostgresProjet.DAL.Interfaces
{
    public interface IDossierPatientRepository : IRepository<Dossierpatients>
    {
        Task<Dossierpatients> GetByPatientIdAsync(int patientId);
        Task<bool> PatientHasDossierAsync(int patientId);
    }
}
