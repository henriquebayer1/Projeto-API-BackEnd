using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O campo de email e obrigatorio!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "O campo de senha e obrigatorio!")]
        public string Senha { get; set; }

        public int IdTipoUsuario { get; set; }

        public TiposUsuarioDomain tipoDeUsuario { get; set; }

        


    }
}
