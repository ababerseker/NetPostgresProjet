using Microsoft.EntityFrameworkCore;
using NetPostgresProjet.DAL.Data;
using NetPostgresProjet.DAL.Interfaces;
using NetPostgresProjet.DAL.Models;
using System.Threading.Tasks;

namespace NetPostgresProjet.DAL.Repositories
{
    public class DossierPatientRepository : BaseRepository<Dossierpatients>, IDossierPatientRepository
    {
        public DossierPatientRepository(HospitalDbContext context) : base(context) { }

        public async Task<Dossierpatients?> GetByPatientIdAsync(int patientId)
        {
            // Version minimale qui compile
            return await _dbSet.FirstOrDefaultAsync();
        }

        public async Task<bool> PatientHasDossierAsync(int patientId)
        {
            // Version minimale qui compile
            return await Task.FromResult(false);
        }
    }
}
