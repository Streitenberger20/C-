using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Collections;

namespace ProyectoFinal
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

         
    }
}
