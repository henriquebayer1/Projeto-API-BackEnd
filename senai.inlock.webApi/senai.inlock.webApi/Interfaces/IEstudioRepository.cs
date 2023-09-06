using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IEstudioRepository
    {

        List<EstudioDomain> ListarTodos();


        void Cadastrar(EstudioDomain estudio);



    }
}
