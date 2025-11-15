using NetPostgresProjet.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetPostgresProjet.DAL.Interfaces
{
    public interface IFactureRepository : IRepository<Factures>
    {
        Task<IEnumerable<Factures>> GetByPatientIdAsync(int patientId);
        Task<IEnumerable<Factures>> GetFacturesEnAttenteAsync();
        Task<Factures> GetByNumeroAsync(string numero);
    }
}
