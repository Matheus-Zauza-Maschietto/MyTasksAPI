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
using MyTasksAPI.Services;


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

            if(user == null)
            {
                return new ResponseUserDto{
                    
                };
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


            return new {token = JwtCodeGenerator.GenerateToken(Subject, _configuration), mensagem = "Usuario logado com sucesso"};
        }

        public Object AlterandoSenhaUsuario(UserPasswordUpdateDto dto)
        {
            var user = _context.FindByEmailAsync(dto.email);


            return new {};
        }
    }
}