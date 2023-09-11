using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.Data;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogoController : ControllerBase
    {

        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();

        }
            


        [HttpGet]
        [Authorize(Roles = "1, 2")]

        public IActionResult GetJogos()
        {

            try
            {
               List<JogoDomain> jogos = _jogoRepository.ListarTodos();


                return Ok(jogos);
            }
            catch (Exception erro)
            {
            
                return BadRequest(erro.Message);
            }
        }


        
        [HttpPost]
        [Authorize(Roles = "2")]

        public IActionResult PostJogo(JogoDomain jogo)
        {

            try
            {
                _jogoRepository.Cadastrar(jogo);


                return StatusCode(202);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }


    }
}
