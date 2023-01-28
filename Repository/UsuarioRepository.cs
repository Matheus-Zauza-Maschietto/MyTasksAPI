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
    }
}