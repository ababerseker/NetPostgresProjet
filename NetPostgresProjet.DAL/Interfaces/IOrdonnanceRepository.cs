using NetPostgresProjet.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetPostgresProjet.DAL.Interfaces
{
    public interface IOrdonnanceRepository : IRepository<Ordonnances>
    {
        Task<IEnumerable<Ordonnances>> GetByPatientIdAsync(int patientId);
        Task<IEnumerable<Ordonnances>> GetByMedecinIdAsync(int medecinId);
        Task<IEnumerable<Ordonnances>> GetOrdonnancesRecentAsync(int days = 30);
    }
}
