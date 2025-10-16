using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPostgresProjet.DAL.Data;
using NetPostgresProjet.DAL.Models;

namespace NetPostgresProjet.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdonnancesController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public OrdonnancesController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordonnances>>> GetOrdonnances()
            => await _context.Ordonnances.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Ordonnances>> GetOrdonnances(int id)
        {
            var entity = await _context.Ordonnances.FindAsync(id);
            if (entity == null) return NotFound();
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Ordonnances>> PostOrdonnances(Ordonnances entity)
        {
            _context.Ordonnances.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetOrdonnances", new { id = entity.Idordonnance }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdonnances(int id, Ordonnances entity)
        {
            if (id != entity.Idordonnance) return BadRequest();
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdonnances(int id)
        {
            var entity = await _context.Ordonnances.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Ordonnances.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
