using Microsoft.AspNetCore.Mvc;
using NetPostgresProjet.BLL.Services;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;


namespace NetPostgresProjet.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public LoginController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDto login)
        {
            // Vérification simple (à remplacer par ta DB)
            if (login.Username == "admin" && login.Password == "123456")
            {
                string token = _tokenService.GenerateToken(login.Username);
                return Ok(new { token });
            }

            return Unauthorized(new { message = "Identifiants invalides" });
        }
    }

    public class LoginDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
