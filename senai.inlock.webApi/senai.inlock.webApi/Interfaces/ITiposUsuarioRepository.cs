using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface ITiposUsuarioRepository
    {


        List<TiposUsuarioDomain> ListarTodos();

        void Cadastrar(TiposUsuarioDomain tipoDeUsuario);


    }
}
