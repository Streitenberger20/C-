using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestion
{
    internal class ProductoVendido
    {
        private long _id;
        private int _idProducto;
        private long _stock;
        private long _idVenta;

        public ProductoVendido(long id, int idProducto, long stock, long idVenta)
        {
            Id = id;
            IdProducto = idProducto;
            Stock = stock;
            IdVenta = idVenta;
        }

        public long Id { get => _id; set => _id = value; }
        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public long Stock { get => _stock; set => _stock = value; }
        public long IdVenta { get => _idVenta; set => _idVenta = value; }

        public static List<ProductoVendido> traerProductosVendidos(long idusr)
        {
            List<ProductoVendido> productos = null;

            string connectionString = "Data Source=DESKTOP-SPVRK7B;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("SELECT productoVendido.id, productoVendido.stock, productoVendido.idProducto, productoVendido.idVenta FROM productoVendido INNER JOIN venta ON venta.idUsuario = @par AND venta.id = productoVendido.idVenta", connection);
                var parametro = new SqlParameter();
                parametro.ParameterName = "par";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = idusr;
                command.Parameters.Add(parametro);


                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    productos = new List<ProductoVendido>();

                    while (reader.Read())
                    {

                        productos.Add(new ProductoVendido(reader.GetInt64(0), reader.GetInt32(1), reader.GetInt64(2), reader.GetInt64(3)));
                    }
                }

            }
            return productos;
        }
    }
}
