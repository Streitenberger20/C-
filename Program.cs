using System.Data;
using System.Data.SqlClient;

namespace SistemaGestion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string connecionString = "Data Source=DESKTOP-SPVRK7B;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //using (SqlConnection connection = new SqlConnection(connecionString))
            //{
            //    List<Usuario> usuarios = new List<Usuario>();

            //    SqlCommand comando = new SqlCommand("SELECT * FROM Usuario", connection);
            //    connection.Open();
            //    SqlDataReader  reader = comando.ExecuteReader();

            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            usuarios.Add(new Usuario(reader.GetInt64(0),reader.GetString(1), reader.GetString(2),reader.GetString(3), reader.GetString(4),reader.GetString(5)));


            //        }

            //        foreach (var item in usuarios){
            //            Console.WriteLine(item.Nombre +" "+ item.Apellido);
            //        }
            //    }



            //    connection.Close();

            //} ;


            List<ProductoVendido> productos = ProductoVendido.traerProductosVendidos(2);


            Console.WriteLine(productos.Count);


         }
    }
}