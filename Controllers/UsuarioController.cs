using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyTasksAPI.Repository;
using MyTasksAPI.Dto.UserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using MyTasksAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MyTasksAPI.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _repository;

        public UsuarioController(UsuarioRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpPost] 
        public IActionResult CadastroUsuario(LoginDto dto)
        {
            if(!Validations.EmailValidation(dto.Email))
                return BadRequest(new {mensagem = "O email enviado não é valido"});

            var user = new IdentityUser
            {
                UserName = dto.Email,
                Email = dto.Email
            };
            var result = _repository.CriarUsuario(user, dto.Password);
            if(result)
            {   
                return Ok(new {mensagem = "Usuario Cadastrado com sucesso"});
            }
            return BadRequest(new {mensagem = "Não foi possivel fazer login"});
        }   

        // [HttpPut]
        // public IActionResult AlterandoSenhaUsuario(UserPasswordUpdateDto)
        // {
            
        // }
    }
}