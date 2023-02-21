using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPut]
        public void actualizarUsuario( Usuario usuario)
        {
            UsuarioHandler.modificarUsuario(usuario);
        }
    }
}
