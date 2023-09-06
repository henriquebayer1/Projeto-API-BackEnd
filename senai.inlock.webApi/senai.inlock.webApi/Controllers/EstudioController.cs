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
    public class EstudioController : ControllerBase
    {

        private IEstudioRepository _EstudioRepository { get; set; }

        public EstudioController()
        {

            _EstudioRepository = new EstudioRepository();
        
        }


        [HttpGet]

        public IActionResult GetEstudio()
        { 
      

            try
            {

                List<EstudioDomain> Estudios = _EstudioRepository.ListarTodos();

                return Ok(Estudios);
            
            }
            catch(Exception erro)
            { 
            
                return BadRequest(erro.Message);
            }
        
        
        }

        [HttpPost]

        public IActionResult PostEstudio(EstudioDomain estudio)
        {

            try
            {
                _EstudioRepository.Cadastrar(estudio);


                return StatusCode(202);
            }
            catch(Exception erro)
            {

                return BadRequest(erro.Message);    
            }

        }

    }
}
