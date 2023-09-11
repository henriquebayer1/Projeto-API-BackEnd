using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();

        }



        [HttpGet]

        public IActionResult GetJogos()
        {

            try
            {
                List<UsuarioDomain> Usuarios = _usuarioRepository.ListarTodos();


                return Ok(Usuarios);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }


        [HttpPost]

        public IActionResult PostJogo(UsuarioDomain Usuario)
        {

            try
            {
                _usuarioRepository.Cadastrar(Usuario);


                return StatusCode(202);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }



        [HttpPost("Login")]

        public IActionResult Get(UsuarioDomain usuario)
        {

            try
            {

                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuarioBuscado == null)
                {

                    return NotFound("Email ou Senha invalidos!");
                }

                //Caso encontre o usuario, prossegue para a criacao do token


                // 1 - Definir as informacoes ou (clains) que serao fornecidos no token (PAYLOAD)

                var claims = new[]
                {

                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role ,usuarioBuscado.IdTipoUsuario.ToString()),


                };

                // 2 - Definir a chave de acesso ao token

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senai.inlock.webApi-chave-autenticacao-webapi-dev"));

                // 3 - Definir as credenciais do token (HEADER)

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // 4 - Gerar Token

                var token = new JwtSecurityToken
                    (
                    //emissor do token
                    issuer: "senai.inlock.webApi",

                    //DESTINATARIO DO TOKEN
                    audience: "senai.inlock.webApi",

                    //DADOS DEFINIDOS NAS CLAINS(INFORMACOES)
                    claims: claims,

                    //TEMPO DE EXPIRACAO DO TOKEN
                    expires: DateTime.Now.AddMinutes(5),

                    //CREDENCIAIS DO TOKEN
                    signingCredentials: creds

                    );

                // 5 Retornar o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)

                });
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

        }







    }
}
