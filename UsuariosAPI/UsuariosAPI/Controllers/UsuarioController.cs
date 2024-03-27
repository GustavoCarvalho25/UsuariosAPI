using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data;
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
        private UsuarioDbContext _userContext;

        public UsuarioController(UsuarioService usuarioService, UsuarioDbContext userContext)
        {
            _usuarioService = usuarioService;
            _userContext = userContext;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuario
        (
            CreateUsuarioDto createUsuarioDto
        )
        {
            await _usuarioService.CadastraUsuarioAsync(createUsuarioDto);
            return Ok("Usuario cadastrado com sucesso!!!");
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUsuarioDto loginDto)
        {
            var token = await _usuarioService.LoginAsync(loginDto);
            return Ok(token);
        }
    }
}
