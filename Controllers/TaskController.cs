using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTasksAPI.Dto.TaskDto;
using MyTasksAPI.Models;
using MyTasksAPI.Repository;

namespace MyTasksAPI.Controllers
{   
    [ApiController]
    [Route("/task")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TaskController: ControllerBase
    {
        private readonly TaskRepository _repository;
        public TaskController(TaskRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult CriarTask(TaskDto dto)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);

            var taskResponse = _repository.CriarTask(dto, email);

            if(taskResponse.TaskId is not null)
                return Ok(taskResponse);

            return BadRequest(taskResponse);
            
        }

        [HttpGet]
        public IActionResult BuscarTask()
        {
            string email = User.FindFirstValue(ClaimTypes.Email);

            var Tasks = _repository.BuscarTarefasEmail(email);
            if(Tasks.Count == 0)
                return NotFound(new TaskDtoResponse(erros: new List<string>{$"Nenhuma task foi encontrada para o usuario {email}"}));
            return Ok(Tasks);
        }

        [HttpPut("{id}")]
        public IActionResult AlterarTask(Guid id, TaskDto dto)
        {
            var TaskResponse = _repository.AlterarTask(dto, id);

            if(TaskResponse.TaskId is not null)
                return Ok(TaskResponse);

            return BadRequest(TaskResponse);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarTask(Guid id)
        {
            var TaskResponse = _repository.DeletarTask(id);

            if(TaskResponse.TaskId is not null)
                return Ok(TaskResponse);

            return BadRequest(TaskResponse);
        }   
    } 
} 