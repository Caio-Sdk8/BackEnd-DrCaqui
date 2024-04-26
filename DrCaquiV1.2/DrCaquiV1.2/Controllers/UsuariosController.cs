using DrCaquiV1._2.Domains;
using DrCaquiV1._2.Interfaces;
using DrCaquiV1._2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DrCaquiV1._2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        Criptografia crypt = new Criptografia();

        public UsuariosController(IUsuarioRepository UsuarioRepository)
        {
            _UsuarioRepository = UsuarioRepository;
        }

        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            _UsuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        //[Authorize(Roles = "1")]
        [HttpPut]
        public IActionResult Alterar(int id, Usuario attUsuario)
        {
            _UsuarioRepository.Alterar(id, attUsuario);

            return StatusCode(204);
        }

        [HttpPost("Login")]
        public IActionResult Login(string login, string senha)
        {
            try
            {
                Usuario u = new Usuario();

                u = _UsuarioRepository.Login(login, senha);

                if (u == null)
                {
                    return BadRequest("E-mail ou senha inválidos!");
                }

                var minhasClaims = new[]{
                    new Claim(JwtRegisteredClaimNames.Name, u.NomeUsuario),
                    new Claim(JwtRegisteredClaimNames.Jti, u.IdUsuario.ToString()),
                    new Claim("role", u.IdTipoUsuario.ToString()),
                    new Claim("id", u.IdUsuario.ToString())
                }; 
                
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("DoutorCaqui-password-backendcsdk"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                        issuer: "DrCaqui_WebApi",
                        audience: "DrCaqui_WebApi",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddHours(3),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
