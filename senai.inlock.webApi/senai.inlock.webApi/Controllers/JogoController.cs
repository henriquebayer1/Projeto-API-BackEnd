using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogoController : ControllerBase
    {





        [HttpGet]

        public IActionResult GetJogos(JogoDomain jogo)
        {

            try
            {

            }
            catch (Exception erro)
            {
            
                return BadRequest(erro.Message);
            }

        }


    }
}
