using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPostgresProjet.DAL.Data;

namespace NetPostgresProjet.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbTestController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public DbTestController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet("connection")]
        public async Task<IActionResult> TestConnection()
        {
            try
            {
                var canConnect = await _context.Database.CanConnectAsync();
                var dbName = _context.Database.GetDbConnection().Database;
                
                return Ok(new { 
                    success = true,
                    database = dbName,
                    canConnect = canConnect,
                    message = "Connexion à la base HOSPITAL réussie"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { 
                    success = false,
                    error = ex.Message,
                    details = ex.InnerException?.Message
                });
            }
        }

        [HttpGet("tables")]
        public async Task<IActionResult> GetTablesInfo()
        {
            try
            {
                var result = new
                {
                    canConnect = await _context.Database.CanConnectAsync(),
                    patientsCount = await _context.Patients.CountAsync(),
                    employesCount = await _context.Employes.CountAsync(),
                    rendezVousCount = await _context.Rendezvous.CountAsync(),
                    chambresCount = await _context.Chambres.CountAsync(),
                    hospitalisationsCount = await _context.Hospitalisations.CountAsync(),
                    ordonnancesCount = await _context.Ordonnances.CountAsync(),
                    facturesCount = await _context.Factures.CountAsync(),
                    dossierPatientsCount = await _context.Dossierpatients.CountAsync()
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
