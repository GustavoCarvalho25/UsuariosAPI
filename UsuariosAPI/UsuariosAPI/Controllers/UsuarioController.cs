using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;

namespace UsuariosAPI.Controllers
{
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastraUsuario
        (
            CreateUsuarioDto createUsuarioDto
        )
        {
            throw new NotImplementedException();
        }
    }
}
