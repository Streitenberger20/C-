using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    internal class UsuarioHandler
    {
        public static Usuario obtenerUsuario(int i)
        {
            Usuario resultado = new Usuario();

            string connectionString = "Data Source=DESKTOP-SPVRK7B;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("SELECT * FROM Usuario WHERE id = @par", connection);
                var parametro = new SqlParameter();
                parametro.ParameterName = "par";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = i;
                command.Parameters.Add(parametro);


                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        resultado = new Usuario(reader.GetInt64(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    }
                }

            }
            return resultado;
        }

        public static Usuario iniciarSesion(string usr, string pwd)
        {
            Usuario resultado = new Usuario();


            string connectionString = "Data Source=DESKTOP-SPVRK7B;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("SELECT * FROM usuario WHERE NombreUsuario = @par1 AND Contraseña = @par2", connection);
                var parametro1 = new SqlParameter();
                var parametro2 = new SqlParameter();
                parametro1.ParameterName = "par1";
                parametro1.SqlDbType = SqlDbType.VarChar;
                parametro1.Value = usr;
                parametro2.ParameterName = "par2";
                parametro2.SqlDbType = SqlDbType.VarChar;
                parametro2.Value = pwd;
                command.Parameters.Add(parametro1);
                command.Parameters.Add(parametro2);


                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    resultado = new Usuario();

                    while (reader.Read())
                    {

                        resultado.Id = reader.GetInt64(0);
                        resultado.Nombre = reader.GetString(1);
                        resultado.Apellido = reader.GetString(2);
                        resultado.NombreUsuario = reader.GetString(3);
                        resultado.Contraseña = reader.GetString(4);
                        resultado.Mail = reader.GetString(5);
                    }
                }

            }
            return resultado;

        }

        public static void modificarUsuario(Usuario usuario)
        {
            string connectionString = "Data Source=DESKTOP-SPVRK7B;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                var query = @"UPDATE Usuario
                              SET Nombre = @Nombre,
                               Apellido = @Apellido,
                               NombreUsuario = @NombreUsuario,
                               Contraseña = @Contraseña,
                               Mail = @Mail
                              WHERE Id = Id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = usuario.Id });
                    command.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                    command.Parameters.Add(new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                    command.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                    command.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = usuario.Contraseña });
                    command.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.Mail });
                    command.ExecuteNonQuery();
                }
                connection.Close();




            }
        }

    }
}
