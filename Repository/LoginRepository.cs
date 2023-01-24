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
    public class LoginRepository
    {
        private readonly UserManager<IdentityUser> _context;
        private readonly IConfiguration _configuration;
        public LoginRepository(UserManager<IdentityUser> context, IConfiguration configuration)
        {
            _context = context; 
            _configuration = configuration;           
        }

        public ResponseUserDto Logar(LoginDto dto){
            var user = _context.FindByEmailAsync(dto.Email).Result;

            if(user == null)
            { 
                return new ResponseUserDto(erros: new List<string>{"Usuario não encontrado"});
            }

            if(!_context.CheckPasswordAsync(user, dto.Password).Result)
            {
                return new ResponseUserDto(erros: new List<string>{"Senha incorreta"});
            }
            var Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, dto.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            });

            return new ResponseUserDto(email: user.Email,
                                       jwtToken: JwtCodeGenerator.GenerateToken(Subject, _configuration),
                                       erros: new List<string>());
        }
    }
}