using Core.Model;
using Core.Repository;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository {
    public class AmigoRepository : IAmigo {

        private string connectionString;

        public AmigoRepository() {
            this.connectionString = @"Server=tcp:azure-tp3.database.windows.net,1433;Initial Catalog=azure-tp3;Persist Security Info=False;User ID=httpsantos;Password=segredo.3#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public Amigo Buscar(int id) {
            var amigo = new Amigo();

            using(SqlConnection conn = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "sp_Busca_Amigo";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("idAmigo", id);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while(dr.Read()) {
                    amigo.Id = Convert.ToInt32(dr["Id"]);
                    amigo.Nome = dr["Nome"].ToString();
                    amigo.Telefone = dr["Telefone"].ToString();

                    try {
                        amigo.DataDeNascimento = Convert.ToDateTime(dr["DataDeNascimento"]);
                    } catch {
                        amigo.DataDeNascimento = null;
                    }

                }
            }
            return amigo;
        }

        public async Task<bool> Salvar(Amigo amigo) {
            var salvou = false;
            try {
                using(var db = new DatabaseContext(connectionString)) {
                    db.Amigos.Add(amigo);
                    await db.SaveChangesAsync();
                    salvou = true;
                }
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            return salvou;
        }
    }
}
