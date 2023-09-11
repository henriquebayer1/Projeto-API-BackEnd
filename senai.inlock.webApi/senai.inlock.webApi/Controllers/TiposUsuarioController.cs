using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposUsuarioController : ControllerBase
    {


        private ITiposUsuarioRepository _tiposUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();

        }



        [HttpGet]

        public IActionResult GetJogos()
        {

            try
            {
                List<TiposUsuarioDomain> TiposUsuarios = _tiposUsuarioRepository.ListarTodos();


                return Ok(TiposUsuarios);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }


        [HttpPost]

        public IActionResult PostJogo(TiposUsuarioDomain TiposUsuario)
        {

            try
            {
                _tiposUsuarioRepository.Cadastrar(TiposUsuario);


                return StatusCode(202);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }







    }
}
