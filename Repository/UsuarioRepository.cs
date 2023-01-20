using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyTasksAPI.Context;
using MyTasksAPI.Models;
using MyTasksAPI.Dto.UserDto;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace MyTasksAPI.Repository
{
    public class UsuarioRepository
    {
        private readonly UserManager<IdentityUser> _context;
        private readonly IConfiguration _configuration;
        public UsuarioRepository(UserManager<IdentityUser> context, IConfiguration configuration)
        {
            _context = context; 
            _configuration = configuration;           
        }

        public bool CriarUsuario(IdentityUser user, string password)
        {
            var result = _context.CreateAsync(user, password).Result;
            return result.Succeeded;
        }

        public Object BuscandoUsuario(UserDto dto)
        {
            var user = _context.FindByEmailAsync(dto.email).Result;
            
            string token;

            if(user == null)
            {
                return new {token = "", mensagem = "Usuario não encontrada"};
            }

            if(!_context.CheckPasswordAsync(user, dto.password).Result)
            {
                return new {token = "", mensagem = "Senha incorreta"};
            }

            var Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, dto.email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            });

            var key = Encoding.ASCII.GetBytes(_configuration["JwtBearerTokenSettings:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = Subject,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _configuration["JwtBearerTokenSettings:Audience"],
                Issuer = _configuration["JwtBearerTokenSettings:Issuer"],
                Expires = DateTime.UtcNow.AddMinutes(6)
            };
            
            var TokenHandler = new JwtSecurityTokenHandler();

            var pretoken = TokenHandler.CreateToken(tokenDescriptor);
            token = TokenHandler.WriteToken(pretoken);
            return new {token = token, mensagem = "Usuario logado com sucesso"};
        }
    }
}