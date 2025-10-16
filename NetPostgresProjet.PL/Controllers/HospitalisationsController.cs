using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPostgresProjet.DAL.Data;
using NetPostgresProjet.DAL.Models;

namespace NetPostgresProjet.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalisationsController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public HospitalisationsController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospitalisations>>> GetHospitalisations()
            => await _context.Hospitalisations.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Hospitalisations>> GetHospitalisations(int id)
        {
            var entity = await _context.Hospitalisations.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Hospitalisations>> PostHospitalisations(Hospitalisations entity)
        {
            _context.Hospitalisations.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetHospitalisations", new { id = entity.Idhospitalisation }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitalisations(int id, Hospitalisations entity)
        {
            if (id != entity.Idhospitalisation) return BadRequest();
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospitalisations(int id)
        {
            var entity = await _context.Hospitalisations.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Hospitalisations.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
