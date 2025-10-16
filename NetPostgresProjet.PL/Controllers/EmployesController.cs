using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPostgresProjet.DAL.Data;
using NetPostgresProjet.DAL.Models;

namespace NetPostgresProjet.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployesController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public EmployesController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employes>>> GetEmployes()
            => await _context.Employes.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Employes>> GetEmploye(int id)
        {
            var employe = await _context.Employes.FindAsync(id);
            if (employe == null) return NotFound();
            return employe;
        }

        [HttpPost]
        public async Task<ActionResult<Employes>> PostEmploye(Employes employe)
        {
            _context.Employes.Add(employe);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEmploye", new { id = employe.Idemploye }, employe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploye(int id, Employes employe)
        {
            if (id != employe.Idemploye) return BadRequest();
            _context.Entry(employe).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploye(int id)
        {
            var employe = await _context.Employes.FindAsync(id);
            if (employe == null) return NotFound();
            _context.Employes.Remove(employe);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
