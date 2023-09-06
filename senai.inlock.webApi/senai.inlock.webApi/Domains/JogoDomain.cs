using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {

        public int IdJogo { get; set; }

        [Required(ErrorMessage = "O Titulo ou nome do jogo e obrigatorio!")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "O valor para o jogo e obrigatorio!")]
        public int Valor { get; set; }

        public int IdEstudio { get; set; }

        public EstudioDomain estudio { get; set; }


    }
}
