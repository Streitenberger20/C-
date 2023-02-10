using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Collections;

namespace SistemaGestion
{
    internal class Producto
    {
        private long _id;
        private string _descripcion;
        private SqlMoney _costo;
        private SqlMoney _precioVenta;
        private int _stock;
        private long _idUsuario;

        public Producto()
        {
            Id = 0;
            Descripcion = "";
            Costo = 0;
            PrecioVenta = 0;
            Stock = 0;
            IdUsuario = 0;
        }

        public Producto(long id, string descripcion, SqlMoney costo, SqlMoney precioVenta, int stock, long idUsuario)
        {
            Id = id;
            Descripcion = descripcion;
            Costo = costo;
            PrecioVenta = precioVenta;
            Stock = stock;
            IdUsuario = idUsuario;
        }

        public long Id { get => _id; set => _id = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public SqlMoney Costo { get => _costo; set => _costo = value; }
        public SqlMoney PrecioVenta { get => _precioVenta; set => _precioVenta = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public long IdUsuario { get => _idUsuario; set => _idUsuario = value; }

         public static List<Producto> traerProductos(long idusr)
        {
            List<Producto> productos = null;

            string connectionString = "Data Source=DESKTOP-SPVRK7B;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario = @par", connection);
                var parametro = new SqlParameter();
                parametro.ParameterName = "par";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = idusr;
                command.Parameters.Add(parametro);


                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    productos = new List<Producto>();

                    while (reader.Read())
                    {

                        productos.Add (new Producto(reader.GetInt64(0), reader.GetString(1), reader.GetSqlMoney(2), reader.GetSqlMoney(3), reader.GetInt32(4), reader.GetInt64(5)));
                    }
                }

            }
            return productos;
        }
    }
}
