using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SistemaGestion
{
    internal class Usuario
    {
        private long _id;
        private string _nombre;
        private string _apellido;
        private string _nombreUsuario;
        private string _contraseña;
        private string _mail;

        public Usuario(long id, string nombre, string apellido, string nombreUsuario, string contraseña, string mail)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            Mail = mail;
        }

        public Usuario()
        {
            Id= 0;
            Nombre = "";
            Apellido = "";
            NombreUsuario = "";
            Contraseña = "";
            Mail = "";
        }

        public long Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Contraseña { get => _contraseña; set => _contraseña = value; }
        public string Mail { get => _mail; set => _mail = value; }

        public static Usuario obtenerUsuario(int i)
        {
            Usuario resultado = null;

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
            Usuario resultado = null;


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
                        resultado.Nombre= reader.GetString(1);
                        resultado.Apellido= reader.GetString(2);
                        resultado.NombreUsuario= reader.GetString(3);
                        resultado.Contraseña= reader.GetString(4);
                        resultado.Mail= reader.GetString(5);
                    }
                }

            }
            return resultado;

        }
    };



}

