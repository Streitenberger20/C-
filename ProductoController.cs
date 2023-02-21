﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        [HttpPost]
        public void nuevoProducto(Producto producto)
        {
            ProductoHandler.crearProducto(producto);
        }

        [HttpPut]
        public void actualizarProducto(Producto producto)
        {
            ProductoHandler.modificarProducto(producto);
        }

        [HttpDelete]
        public void borrarProducto(long idProd)
        {
            ProductoHandler.eliminarProducto(idProd);
        }
    }
}
