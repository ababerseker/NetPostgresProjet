using Microsoft.EntityFrameworkCore;
using NetPostgresProjet.DAL.Data;
using NetPostgresProjet.DAL.Interfaces;
using NetPostgresProjet.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetPostgresProjet.DAL.Repositories
{
    public class ChambresRepository : BaseRepository<Chambres>, IChambresRepository
    {
        public ChambresRepository(HospitalDbContext context) : base(context) { }

        public async Task<IEnumerable<Chambres>> GetChambresDisponiblesAsync()
        {
            // Version minimale qui compile
            return await _dbSet.ToListAsync();
        }

        public async Task<Chambres?> GetByNumeroAsync(string numero)
        {
            // Version minimale qui compile
            return await _dbSet.FirstOrDefaultAsync();
        }

        public async Task<bool> NumeroExistsAsync(string numero, int? excludeId = null)
        {
            // Version minimale qui compile
            return await Task.FromResult(false);
        }
    }
}
