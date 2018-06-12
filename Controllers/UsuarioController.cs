using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiUsuarios.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ApiUsuarios.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IConfiguration configuration;
        public UsuarioController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] User usuario) 
        {
            if(usuario.Nome == "user.name" && usuario.Senha == "pass.word") 
            {
                var claims = new[] 
                {
                    new Claim(ClaimTypes.Name, usuario.Nome)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "isabela",
                    audience: "isabela",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );
                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("Acesso negado");
        }
    }
}