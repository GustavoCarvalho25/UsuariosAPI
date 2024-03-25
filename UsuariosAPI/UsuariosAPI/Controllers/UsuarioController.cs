using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuario
        (
            CreateUsuarioDto createUsuarioDto
        )
        {
            _usuarioService.CadastraUsuarioAsync(createUsuarioDto);
            return Ok("Usuario cadastrado com sucesso!!!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUsuarioDto loginDto)
        {
            await _usuarioService.LoginAsync(loginDto);
            return Ok("Usuario Autenticado!");
        }
    }
}
