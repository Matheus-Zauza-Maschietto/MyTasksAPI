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

    }
}