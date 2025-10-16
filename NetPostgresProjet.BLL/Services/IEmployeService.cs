using NetPostgresProjet.BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetPostgresProjet.BLL.Services
{
    public interface IEmployeService
    {
        Task<List<EmployeDto>> GetAllEmployesAsync();
        Task<List<EmployeDto>> GetMedecinsAsync();
        Task<EmployeDto?> GetEmployeByIdAsync(int id);
    }
}
