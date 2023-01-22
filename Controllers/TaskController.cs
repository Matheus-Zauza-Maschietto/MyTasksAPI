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
            try{
                _repository.CriarTask(task);
                return Ok();
            }
            catch{
                return BadRequest("Ocorreu um erro interno");
            }
            
        }
    }
}