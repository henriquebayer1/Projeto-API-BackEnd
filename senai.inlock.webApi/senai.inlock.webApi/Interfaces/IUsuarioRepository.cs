using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IUsuarioRepository
    {

        List<UsuarioDomain> ListarTodos();

        void Cadastrar(UsuarioDomain Usuario);



    }
}
