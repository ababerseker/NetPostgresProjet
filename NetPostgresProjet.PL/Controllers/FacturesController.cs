using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPostgresProjet.DAL.Data;
using NetPostgresProjet.DAL.Models;

namespace NetPostgresProjet.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturesController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public FacturesController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factures>>> GetFactures()
            => await _context.Factures.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Factures>> GetFactures(int id)
        {
            var entity = await _context.Factures.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Factures>> PostFactures(Factures entity)
        {
            _context.Factures.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFactures", new { id = entity.Idfacture }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactures(int id, Factures entity)
        {
            if (id != entity.Idfacture) return BadRequest();
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactures(int id)
        {
            var entity = await _context.Factures.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Factures.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
