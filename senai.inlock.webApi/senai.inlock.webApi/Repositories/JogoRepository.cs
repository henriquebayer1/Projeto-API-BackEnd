using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;
using System.Drawing;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {

        private string StringConexao = "Data Source = NOTE01-S15; Initial Catalog = inlock_games; User Id = SA; Pwd = Senai@134";

        public void Cadastrar(JogoDomain jogo)
        {
            string queryAdd = "INSERT INTO Jogo(Nome, Descricao, DataLancamento, Valor) VALUES(@Nome, @Des, @Data, @Valor)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {


                using(SqlCommand cmd = new SqlCommand(queryAdd, con)) 
                
                {

                    cmd.Parameters.AddWithValue("@Nome", jogo.Nome);
                    cmd.Parameters.AddWithValue("@Des", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@Data", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);

                    con.Open();

                    cmd.ExecuteNonQuery();


                }


            }
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> jogos = new List<JogoDomain>();

            SqlDataReader rdr;

            string queryList = "SELECT IdJogo, Nome, Descricao, DataLancamento, Valor FROM Estudio";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {


                using (SqlCommand cmd = new SqlCommand(queryList, con))
                {

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        JogoDomain jogo = new JogoDomain()
                        {

                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            Nome = rdr["Nome"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Valor = Convert.ToInt32(rdr["Valor"])
                        };

                       jogos.Add(jogo);

                    }

                    return jogos;

                }





            }




        }
    }
}
