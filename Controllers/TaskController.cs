using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyTasksAPI.Dto.TaskDto;
using MyTasksAPI.Models;
using MyTasksAPI.Repository;

namespace MyTasksAPI.Controllers
{   
    [ApiController]
    [Route("[controller]")]
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
            var task = new Tarefa(dto);
            var taskDto = _repository.CriarTask(task);
            if(taskDto.EmailUsuario is not null)
                return Ok(taskDto);
            return BadRequest("Ocorreu um erro interno");
            
        }

        [HttpGet("{email}")]
        public IActionResult BuscarTask(string email)
        {
            var Tasks = _repository.BuscarTarefasEmail(email);
            if(Tasks.Count == 0)
                return NotFound($"Nenhuma tarefa foi encontrada atrelada ao email {email}");
            return Ok(Tasks);
        }

        [HttpPut("{id}")]
        public IActionResult AlterarTask(Guid id, TaskDto dto)
        {
            if(_repository.AlterarTask(dto, id))
                return Ok(dto);
            return BadRequest("Não foi possivel alterar a task");
                
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarTask(Guid id)
        {
            if(_repository.DeletarTask(id))
                return Ok("Task deletada com sucesso");
            return BadRequest("Ocorreu um erro ao deletar a task");
        }   
    } 
} 