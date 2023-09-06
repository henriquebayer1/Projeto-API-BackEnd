using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IJogoRepository
    {

        List<JogoDomain> ListarTodos();

        void Cadastrar(JogoDomain jogo);

    }
}
