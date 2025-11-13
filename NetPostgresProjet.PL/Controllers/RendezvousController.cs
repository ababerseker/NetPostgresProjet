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
        public async Task<ActionResult<Rendezvous>> PostRendezvous([FromBody] RendezvousCreateDto rendezvousDto)
        {
            try
            {
                // Valider et parser la date
                if (!DateOnly.TryParse(rendezvousDto.Date, out DateOnly date))
                {
                    return BadRequest("Format de date invalide. Utilisez YYYY-MM-DD.");
                }

                // Valider et parser l'heure
                if (!TimeOnly.TryParse(rendezvousDto.Heure, out TimeOnly heure))
                {
                    return BadRequest("Format d'heure invalide. Utilisez HH:mm:ss.");
                }

                // Créer l'entité Rendezvous à partir du DTO
                var rendezvous = new Rendezvous
                {
                    Patientid = rendezvousDto.Patientid,
                    Medecinid = rendezvousDto.Medecinid,
                    Date = date,
                    Heure = heure
                };

                _context.Rendezvous.Add(rendezvous);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetRendezvous", new { id = rendezvous.Idrdv }, rendezvous);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest($"Erreur lors de la sauvegarde: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne: {ex.Message}");
            }
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

    // DTO pour la création (ajoutez cette classe dans le même fichier)
    public class RendezvousCreateDto
    {
        public int Patientid { get; set; }
        public int Medecinid { get; set; }
        public string Date { get; set; } = string.Empty; // Format "YYYY-MM-DD"
        public string Heure { get; set; } = string.Empty; // Format "HH:mm:ss"
    }
}