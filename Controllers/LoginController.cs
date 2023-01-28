using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTasksAPI.Dto.UserDto;
using MyTasksAPI.Repository;

namespace MyTasksAPI.Controllers
{
    [ApiController]
    [Route("/login")]
    public class LoginController: ControllerBase
    {
        private readonly LoginRepository _repository;

        public LoginController(LoginRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult LoginUsuario(LoginDto dto)
        {
            var usuario = _repository.Logar(dto);
            if(usuario.Email is null)
                return NotFound(usuario);

            return Ok(usuario);
        }

        
    }
}