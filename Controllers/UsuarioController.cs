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
        public IActionResult CadastroUsuario(UserDto dto)
        {
            if(!Validations.EmailValidation(dto.email))
                return BadRequest(new {mensagem = "O email enviado não é valido"});

            var user = new IdentityUser
            {
                UserName = dto.email,
                Email = dto.email
            };
            var result = _repository.CriarUsuario(user, dto.password);
            if(result)
            {   
                return Ok(new {mensagem = "Usuario Cadastrado com sucesso"});
            }
            return BadRequest(new {mensagem = "Não foi possivel fazer login"});
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult LoginUsuario(UserDto dto)
        {
            var tokenUsuario = _repository.BuscandoUsuario(dto);
            if(tokenUsuario is not null)
            {
                return Ok(tokenUsuario);
            }
                
            return NotFound(new {mensagem= "Usuario não encontrado"});
        }   

    }
}