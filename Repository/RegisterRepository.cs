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
    public class RegisterRepository
    {
        private readonly UserManager<IdentityUser> _context;
        private readonly IConfiguration _configuration;
        public RegisterRepository(UserManager<IdentityUser> context, IConfiguration configuration)
        {
            _context = context; 
            _configuration = configuration;           
        }

        public ResponseUserDto RegistrarUsuario(RegisterDto dto)
        {
            var user = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email
            };

            var result = _context.CreateAsync(user, dto.Password).Result;

            var Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, dto.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            });

            if(result.Succeeded)
            {
                return new ResponseUserDto(email: dto.Email, jwtToken: JwtCodeGenerator.GenerateToken(Subject, _configuration), erros: new List<string>());
            }
            return new ResponseUserDto(erros: new List<string>{"Ocorreu um erro ao criar sua conta, tente novamente"});
        }

    }
}