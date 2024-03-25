﻿
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    internal class TokenService
    {
        public void GenerateToken(Usuario usuario)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id),
                new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())
            };

            var chave = new SymmetricSecurityKey
                (
                    Encoding.UTF8.GetBytes("9ASHDA98H9ah9ha9H9A89n0f")
                );

            var signingCredentials = 
                new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    expires: DateTime.UtcNow.AddMinutes(10),
                    claims: claims,
                    signingCredentials: signingCredentials
                );
        }
    }
}