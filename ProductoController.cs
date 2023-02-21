using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        [HttpPost("/Producto")]
        public void nuevoProducto(Producto producto)
        {
            ProductoHandler.crearProducto(producto);
        } 
    }
}
