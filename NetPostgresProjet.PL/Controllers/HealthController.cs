using Microsoft.AspNetCore.Mvc;

namespace NetPostgresProjet.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { 
                status = "OK", 
                message = "HOSPITAL Management System API", 
                timestamp = DateTime.UtcNow,
                version = "1.0"
            });
        }
    }
}
