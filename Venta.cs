using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestion
{
    internal class Venta
    {
        private long _id;
        private string _comentarios;
        private long _idUsuario;

        public Venta(long id, string comentarios, long idUsuario)
        {
            Id = id;
            Comentarios = comentarios;
            IdUsuario = idUsuario;
        }

        public long Id { get => _id; set => _id = value; }
        public string Comentarios { get => _comentarios; set => _comentarios = value; }
        public long IdUsuario { get => _idUsuario; set => _idUsuario = value; }

        public static List<Venta> traerVentas(long idusr)
        {
            List<Venta> ventas = null;

            string connectionString = "Data Source=DESKTOP-SPVRK7B;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("SELECT * FROM venta WHERE IdUsuario = @par", connection);
                var parametro = new SqlParameter();
                parametro.ParameterName = "par";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = idusr;
                command.Parameters.Add(parametro);


                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    ventas = new List<Venta>();

                    while (reader.Read())
                    {

                        ventas.Add(new Venta(reader.GetInt64(0), reader.GetString(1), reader.GetInt64(2)));
                    }
                }

            }
            return ventas;
        }
    }
}
