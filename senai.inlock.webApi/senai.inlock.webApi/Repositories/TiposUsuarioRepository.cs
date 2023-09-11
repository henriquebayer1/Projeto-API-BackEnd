using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {

        private string StringConexao = "Data Source = NOTE01-S15; Initial Catalog = inlock_games; User Id = SA; Pwd = Senai@134";

        public void Cadastrar(TiposUsuarioDomain tipoDeUsuario)
        {
            string queryAdd = "INSERT INTO TiposUsuario(Titulo) VALUES(@Titulo)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {


                using (SqlCommand cmd = new SqlCommand(queryAdd, con))

                {

                    cmd.Parameters.AddWithValue("@Titulo", tipoDeUsuario.Titulo);
                   
                    con.Open();

                    cmd.ExecuteNonQuery();


                }


            }
        }

        public List<TiposUsuarioDomain> ListarTodos()
        {
            List<TiposUsuarioDomain> TiposUsuarios = new List<TiposUsuarioDomain>();

            SqlDataReader rdr;

            string queryList = "SELECT IdTipoUsuario, Titulo FROM TiposUsuario";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {


                using (SqlCommand cmd = new SqlCommand(queryList, con))
                {

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        TiposUsuarioDomain TipoUsuario = new TiposUsuarioDomain()
                        {
                            Titulo = rdr["Titulo"].ToString()
                            
                        };

                        TiposUsuarios.Add(TipoUsuario);

                    }

                    return TiposUsuarios;

                }





            }
        }
    }
}
