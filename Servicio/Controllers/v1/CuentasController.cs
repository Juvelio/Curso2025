using Entidades.DTOs;
using Entidades.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Servicio.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Servicio.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public CuentasController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] UserLogin userLogin)
        {          
            var user = await _context.Personas.FirstOrDefaultAsync(u => u.Usuario == userLogin.Username && u.Pass == userLogin.Password);

            if (user == null)
            {
                return Unauthorized("Usuario o coantraseña inconrecta");
            }

            var token = GenerarToken(user); 
            return Ok(token);
        }

        private string GenerarToken(Persona user)
        {
            // CREAMOS EL HEADER
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:ClaveSecreta"]));
            var _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var _header = new JwtHeader(_signingCredentials);

            // CREARMOS LOS CLAIMS
            var _claims = new[]
           {
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim("nombre", user.Nombres),
                 new Claim("paterno", user.Nombres),
                 new Claim("llave", "El valor que yo quiera"),
				 //new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email),
				 new Claim(ClaimTypes.Role, "admin")
            };

            // CREAMOS EL PAYLOAD (CARGA UTIL)
            var _payload = new JwtPayload(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: _claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1)
                );

            // CREAMOS EL TOKEN
            var _token = new JwtSecurityToken(_header, _payload);


            return new JwtSecurityTokenHandler().WriteToken(_token);
        }
    }
}
