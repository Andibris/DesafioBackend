using DesafioApi.Data;
using DesafioApi.Models;
using DesafioApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioApi.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User credentials)
        {
            var user = _context.Users.FirstOrDefault(u =>
                u.Email == credentials.Email &&
                u.Password == credentials.Password);

            if (user == null)
                return Unauthorized(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user, _configuration);
            return Ok(new { token });
        }
    }
}