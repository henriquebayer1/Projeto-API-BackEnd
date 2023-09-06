using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private string StringConexao = "Data Source = NOTE01-S15; Initial Catalog = inlock_games; User Id = SA; Pwd = Senai@134";

        public void Cadastrar(UsuarioDomain Usuario)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
