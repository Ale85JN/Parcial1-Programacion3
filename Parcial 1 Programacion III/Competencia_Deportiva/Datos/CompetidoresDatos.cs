using Competencia_Deportiva.Models;
using System.Data.SqlClient;

namespace Competencia_Deportiva.Datos
{
    public class CompetidoresDatos
    {
        private string connectionString = $@"Data Source=DESKTOP-SJQDT9G\SQLEXPRESS;Initial Catalog=CompetenciaDeportiva_DB;Integrated Security=True";

        public List<Competidores> listarCompetidores()
        {
            List<Competidores> lista = new List<Competidores>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Competidores.Id as IdCompetidor, Competidores.Nombre as NombreCompetidor, Competidores.IdDisciplina, Competidores.Edad, Competidores.CiudadResidencia, Disciplina.Nombre as NombreDisciplina FROM Competidores INNER JOIN Disciplina ON Competidores.IdDisciplina = Disciplina.Id ORDER BY Disciplina.Nombre";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Competidores()
                    {
                        Id = (int)reader["IdCompetidor"],
                        Nombre = reader["NombreCompetidor"].ToString(),
                        IdDisciplina = (int)reader["IdEspecie"],
                        Edad = (int)reader["Edad"],
                        CiudadResidencia = reader["CiudadResidencia"].ToString(),
                        Disciplina = new Disciplina()
                                  {
                                   Id = (int)reader["IdDisciplina"],
                                   Nombre = reader["NombreDisciplina"].ToString()
                                  }
                    });
                }
                return lista;
            }
        }

        public string Crear(Competidores competidores)
        {
            string query = $"INSERT INTO Mascota (Nombre, Edad,CiudadResidencia, IdDisciplina) VALUES ('{competidores.Nombre}', {competidores.Edad}, '{competidores.CiudadResidencia}', {competidores.IdDisciplina})";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }

        public List<Disciplina> ListarDisciplina()
        {
            List<Disciplina> lista = new List<Disciplina>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Disciplina ORDER BY Nombre";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Disciplina()
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString()
                    });
                }
                return lista;
            }
        }
    }
}
