using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private string StringConexao = "Data Source = NOTE01-S15; Initial Catalog = inlock_games; User Id = SA; Pwd = Senai@134";

        public void Cadastrar(UsuarioDomain Usuario)
        {
            string queryAdd = "INSERT INTO Usuario(IdTipoUsuario, Email, Senha) VALUES(@IdTipoUsuario, @Email, @Senha)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {


                using (SqlCommand cmd = new SqlCommand(queryAdd, con))

                {

                    cmd.Parameters.AddWithValue("@IdTipoUsuario", Usuario.IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@Email", Usuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", Usuario.Senha);

                    con.Open();

                    cmd.ExecuteNonQuery();


                }


            }
        }



        public List<UsuarioDomain> ListarTodos()
        {
            List<UsuarioDomain> Usuarios = new List<UsuarioDomain>();

            SqlDataReader rdr;

            string queryList = "SELECT IdTipoUsuario, IdUsuario, Email, Senha FROM Usuario";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {


                using (SqlCommand cmd = new SqlCommand(queryList, con))
                {

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        UsuarioDomain Usuario = new UsuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString()

                        };

                        Usuarios.Add(Usuario);

                    }

                    return Usuarios;

                }





            }
        }

        public UsuarioDomain Login(string email, string senha)
        {
            string querySearch = "SELECT IdUsuario, Email, IdTipoUsuario FROM Usuario WHERE Email = @Email AND Senha = @Senha";

            SqlDataReader rdr;

            UsuarioDomain usuarioBuscado = new UsuarioDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {


                using (SqlCommand cmd = new SqlCommand(querySearch, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);


                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        usuarioBuscado.IdUsuario = Convert.ToInt32(rdr["IdUsuario"]);
                        usuarioBuscado.Email = rdr["Email"].ToString();
                        usuarioBuscado.IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]);

                        return usuarioBuscado;

                    }
                    return null;
                }

            }
        }
    }
}
