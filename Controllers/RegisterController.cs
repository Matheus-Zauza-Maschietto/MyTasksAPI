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
    [Route("/cadastro")]
    public class RegisterController: ControllerBase
    {
        private readonly RegisterRepository _repository;

        public RegisterController(RegisterRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CadastroUsuario(RegisterDto dto)
        {
            if(!Validations.EmailValidation(dto.Email))
                return BadRequest(new ResponseUserDto(erros: new List<string>{"O email enviado não é valido"}));

            if(dto.Password != dto.ConfirmPassword)
                return BadRequest(new ResponseUserDto(erros: new List<string>{"As senhas não conhecidem"}));

            var Usuario = _repository.RegistrarUsuario(dto);
            if(Usuario.Email is not null)
            {   
                return Ok(Usuario);
            }
            
            return BadRequest(Usuario);
        }
    }
}