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

        public Amigo Salvar(Amigo amigo) {
            var id = 0;

            using(SqlConnection conn = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Amigo_Insert";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Nome", amigo.Nome);
                cmd.Parameters.AddWithValue("SobreNome", amigo.SobreNome);
                cmd.Parameters.AddWithValue("Email", amigo.Email);
                cmd.Parameters.AddWithValue("Telefone", amigo.Telefone);
                cmd.Parameters.AddWithValue("DataDeNascimento", amigo.DataDeNascimento);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while(dr.Read()) {
                    id = Convert.ToInt32(dr["Id"]);
                }
            }

            var amigo_salvo = Buscar(id);

            return amigo_salvo;
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
                    amigo.SobreNome = dr["SobreNome"].ToString();
                    amigo.Email = dr["Email"].ToString();
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

        public List<Amigo> Listar() {
            List<Amigo> amigos = new List<Amigo>();

            using(SqlConnection conn = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Amigo_Listar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while(dr.Read()) {
                    var amigo = new Amigo();

                    amigo.Id = Convert.ToInt32(dr["Id"]);
                    amigo.Nome = dr["Nome"].ToString();
                    amigo.Email = dr["SobreNome"].ToString();
                    amigo.Telefone = dr["Telefone"].ToString();

                    try {
                        amigo.DataDeNascimento = Convert.ToDateTime(dr["DataDeNascimento"]);
                    } catch {
                        amigo.DataDeNascimento = null;
                    }
                    amigos.Add(amigo);
                }
            }

            return amigos;
        }

        public Amigo Editar(Amigo amigo) {
            using(SqlConnection conn = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Amigo_Update";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", amigo.Id);
                cmd.Parameters.AddWithValue("Nome", amigo.Nome);
                cmd.Parameters.AddWithValue("SobreNome", amigo.SobreNome);
                cmd.Parameters.AddWithValue("Email", amigo.Email);
                cmd.Parameters.AddWithValue("Telefone", amigo.Telefone);
                cmd.Parameters.AddWithValue("DataDeNascimento", amigo.DataDeNascimento);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            var amigo_editado = Buscar(amigo.Id);
            return amigo_editado;
        }

        public void Apagar(int Id) {
            using(SqlConnection conn = new SqlConnection(connectionString)) {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Amigo_Delete";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", Id);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public Amigo SalvarEF(Amigo amigo) {
            try {
                using(var db = new DatabaseContext(connectionString)) {
                    db.Amigos.Add(amigo);
                    db.SaveChanges();
                    return amigo;
                }
            } catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
