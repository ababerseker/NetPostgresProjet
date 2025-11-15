using Microsoft.EntityFrameworkCore;
using NetPostgresProjet.DAL.Data;
using NetPostgresProjet.DAL.Interfaces;
using NetPostgresProjet.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetPostgresProjet.DAL.Repositories
{
    public class HospitalisationRepository : BaseRepository<Hospitalisations>, IHospitalisationRepository
    {
        public HospitalisationRepository(HospitalDbContext context) : base(context) { }

        public async Task<IEnumerable<Hospitalisations>> GetByPatientIdAsync(int patientId)
        {
            // Version minimale qui compile
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Hospitalisations>> GetHospitalisationsEnCoursAsync()
        {
            // Version minimale qui compile
            return await _dbSet.ToListAsync();
        }

        public async Task<Hospitalisations?> GetActiveByPatientIdAsync(int patientId)
        {
            // Version minimale qui compile
            return await _dbSet.FirstOrDefaultAsync();
        }
    }
}
