using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    internal class ProductoHandler
    {
        public static List<Producto> traerProductos(long idusr)
        {
            List<Producto> productos = new List<Producto>();

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

                        productos.Add(new Producto(reader.GetInt64(0), reader.GetString(1), reader.GetSqlMoney(2), reader.GetSqlMoney(3), reader.GetInt32(4), reader.GetInt64(5)));
                    }
                }

            }
            return productos;
        }

        public static void crearProducto(Producto producto)
        {

            string connectionString = "Data Source=DESKTOP-SPVRK7B;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var query = @"INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) 
                            VALUES(@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario )"; 
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripcion });
                    command.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value= producto.Costo});
                    command.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = producto.PrecioVenta});
                    command.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock });
                    command.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario });
                    command.ExecuteNonQuery();
            }
                connection.Close();

        }
    }

        public static void modificarProducto(Producto producto)
        {
            string connectionString = "Data Source=DESKTOP-SPVRK7B;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                var query = @"UPDATE Producto
                              SET Descripciones = @Descripciones,
                               Costo = @costo,
                               PrecioVenta = @PrecioVenta,
                               Stock = @Stock,
                               IdUsuario = @IdUsuario
                              WHERE Id = @Id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = producto.Id });
                    command.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripcion });
                    command.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value = producto.Costo });
                    command.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = producto.PrecioVenta });
                    command.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock });
                    command.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario });
                    command.ExecuteNonQuery();
                }
                connection.Close();

            }
        }

        public static void eliminarProducto(long idproducto) 
        {
            string connectionString = "Data Source=DESKTOP-SPVRK7B;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                var query = @"DELETE FROM Producto WHERE Id = @Id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", SqlDbType.BigInt) { Value = idproducto });
                    command.ExecuteNonQuery();
                }
                connection.Close();

            }
        }
    }
}
