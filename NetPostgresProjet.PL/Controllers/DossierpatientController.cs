using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPostgresProjet.DAL.Data;
using NetPostgresProjet.DAL.Models;

namespace NetPostgresProjet.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DossierpatientController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public DossierpatientController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dossierpatients>>> GetDossierpatient()
            => await _context.Dossierpatients.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Dossierpatients>> GetDossierpatient(int id)
        {
            var entity = await _context.Dossierpatients.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Dossierpatients>> PostDossierpatient(Dossierpatients entity)
        {
            _context.Dossierpatients.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDossierpatient", new { id = entity.Iddossier }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDossierpatient(int id, Dossierpatients entity)
        {
            if (id != entity.Iddossier) return BadRequest();
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDossierpatient(int id)
        {
            var entity = await _context.Dossierpatients.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Dossierpatients.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
