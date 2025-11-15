using Microsoft.EntityFrameworkCore;
using NetPostgresProjet.DAL.Data;
using NetPostgresProjet.DAL.Interfaces;
using NetPostgresProjet.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetPostgresProjet.DAL.Repositories
{
    public class OrdonnanceRepository : BaseRepository<Ordonnances>, IOrdonnanceRepository
    {
        public OrdonnanceRepository(HospitalDbContext context) : base(context) { }

        public async Task<IEnumerable<Ordonnances>> GetByPatientIdAsync(int patientId)
        {
            // Version minimale qui compile
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Ordonnances>> GetByMedecinIdAsync(int medecinId)
        {
            // Version minimale qui compile
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<Ordonnances>> GetOrdonnancesRecentAsync(int days = 30)
        {
            // Version minimale qui compile
            return await _dbSet.ToListAsync();
        }
    }
}
