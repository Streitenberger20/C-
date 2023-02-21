using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
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

        
    }
}
