using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EL.FredericoRibeiro.Domain.Entities;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using EL.FredericoRibeiro.Domain.DbModels;

namespace EL.FredericoRibeiro.Application.Services
{
    public static class TokenService
    {
        public static string GenerateToken(UsuarioDbModel usuarioDbModel) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuarioDbModel.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioDbModel.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
