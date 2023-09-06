using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string StringConexao = "Data Source = NOTE01-S15; Initial Catalog = inlock_games; User Id = SA; Pwd = Senai@134";

        public void Cadastrar(EstudioDomain estudio)
        {
            string queryAdd = "INSERT INTO Estudio(Nome) VALUES(@Nome)";


            using(SqlConnection con = new SqlConnection(StringConexao))
            {


                using (SqlCommand cmd = new SqlCommand(queryAdd, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", estudio.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }

            }



        }

        public List<EstudioDomain> ListarTodos()
        {
            
            List<EstudioDomain> Estudios = new List<EstudioDomain>();

            SqlDataReader rdr;

            string queryList = "SELECT IdEstudio, Nome FROM Estudio";

            using(SqlConnection con = new SqlConnection(StringConexao))
            {


                using (SqlCommand cmd = new SqlCommand(queryList, con))
                {

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {

                        EstudioDomain estudio = new EstudioDomain()
                        {

                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString()


                        };

                        Estudios.Add(estudio);

                    }

                    return Estudios;

                }
                




            }


        }
    }
}



