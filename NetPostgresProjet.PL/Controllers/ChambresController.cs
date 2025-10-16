using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPostgresProjet.DAL.Data;
using NetPostgresProjet.DAL.Models;

namespace NetPostgresProjet.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChambresController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public ChambresController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chambres>>> GetChambres() 
            => await _context.Chambres.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Chambres>> GetChambre(int id)
        {
            var chambre = await _context.Chambres.FindAsync(id);
            if (chambre == null) return NotFound();
            return chambre;
        }

        [HttpPost]
        public async Task<ActionResult<Chambres>> PostChambre(Chambres chambre)
        {
            _context.Chambres.Add(chambre);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetChambre", new { id = chambre.Idchambre }, chambre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutChambre(int id, Chambres chambre)
        {
            if (id != chambre.Idchambre) return BadRequest();
            _context.Entry(chambre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChambre(int id)
        {
            var chambre = await _context.Chambres.FindAsync(id);
            if (chambre == null) return NotFound();
            _context.Chambres.Remove(chambre);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
