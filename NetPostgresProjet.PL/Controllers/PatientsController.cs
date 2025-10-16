using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPostgresProjet.DAL.Data;
using NetPostgresProjet.DAL.Models;

namespace NetPostgresProjet.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public PatientsController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patients>>> GetPatients()
            => await _context.Patients.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Patients>> GetPatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return NotFound();
            return patient;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patients patient)
        {
            if (id != patient.Idpatient) return BadRequest();
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Patients>> PostPatient(Patients patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPatient", new { id = patient.Idpatient }, patient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return NotFound();
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Patients>>> SearchPatients([FromQuery] string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return BadRequest("Search term is required");
            
            var patients = await _context.Patients
                .Where(p => p.Nom.Contains(searchTerm) || p.Prenom.Contains(searchTerm))
                .ToListAsync();
            
            return patients;
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetPatientsCount()
        {
            var count = await _context.Patients.CountAsync();
            return count;
        }
    }
}
