using Microsoft.EntityFrameworkCore;
using NetPostgresProjet.DAL.Data;
using NetPostgresProjet.DAL.Interfaces;
using NetPostgresProjet.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetPostgresProjet.DAL.Repositories
{
    public class FactureRepository : BaseRepository<Factures>, IFactureRepository
    {
        public FactureRepository(HospitalDbContext context) : base(context) { }

        public async Task<IEnumerable<Factures>> GetByPatientIdAsync(int patientId)
        {
            // Version minimale qui compile
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Factures>> GetFacturesEnAttenteAsync()
        {
            // Version minimale qui compile
            return await _dbSet.ToListAsync();
        }

        public async Task<Factures?> GetByNumeroAsync(string numero)
        {
            // Version minimale qui compile
            return await _dbSet.FirstOrDefaultAsync();
        }
    }
}
