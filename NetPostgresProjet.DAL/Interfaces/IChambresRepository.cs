using NetPostgresProjet.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetPostgresProjet.DAL.Interfaces
{
    public interface IChambresRepository : IRepository<Chambres>
    {
        Task<IEnumerable<Chambres>> GetChambresDisponiblesAsync();
        Task<Chambres> GetByNumeroAsync(string numero);
        Task<bool> NumeroExistsAsync(string numero, int? excludeId = null);
    }
}
