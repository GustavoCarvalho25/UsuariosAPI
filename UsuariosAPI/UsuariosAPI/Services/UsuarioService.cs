using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task CadastraUsuarioAsync(CreateUsuarioDto createUsuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createUsuarioDto);

            IdentityResult resultado = await _userManager.
                CreateAsync(usuario, createUsuarioDto.Password);

            if (!resultado.Succeeded)
                throw new ApplicationException("Falha ao cadastra usuario!!!");
        }

        public async Task LoginAsync(LoginUsuarioDto loginDto)
        {
            var resultado = await _signInManager.PasswordSignInAsync
                (
                    loginDto.Username,
                    loginDto.Password,
                    false,
                    false
                );

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuario não autenticado!!!");
            }

            _tokenService.GenerateToken();
        }
    }
}
