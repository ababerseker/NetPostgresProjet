using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPostgresProjet.DAL.Data;
using NetPostgresProjet.DAL.Models;

namespace NetPostgresProjet.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendezvousController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public RendezvousController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rendezvous>>> GetRendezvous()
            => await _context.Rendezvous.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Rendezvous>> GetRendezvous(int id)
        {
            var rendezvous = await _context.Rendezvous.FindAsync(id);
            if (rendezvous == null) return NotFound();
            return rendezvous;
        }

        [HttpPost]
        public async Task<ActionResult<Rendezvous>> PostRendezvous(Rendezvous rendezvous)
        {
            _context.Rendezvous.Add(rendezvous);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetRendezvous", new { id = rendezvous.Idrdv }, rendezvous);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRendezvous(int id, Rendezvous rendezvous)
        {
            if (id != rendezvous.Idrdv) return BadRequest();
            _context.Entry(rendezvous).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRendezvous(int id)
        {
            var rendezvous = await _context.Rendezvous.FindAsync(id);
            if (rendezvous == null) return NotFound();
            _context.Rendezvous.Remove(rendezvous);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
