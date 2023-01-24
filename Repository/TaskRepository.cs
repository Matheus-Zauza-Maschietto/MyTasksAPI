using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTasksAPI.Context;
using MyTasksAPI.Dto.TaskDto;
using MyTasksAPI.Models;


namespace MyTasksAPI.Repository
{
    public class TaskRepository
    {
        private readonly MyTaskContext _context;
        public TaskRepository(MyTaskContext context)
        {
            _context = context;
        }
 
        public TaskDtoResponse CriarTask(TaskDto dto, string email)
        {
            var task = new Tarefa(dto, email);

            var user = _context.Users.FirstOrDefault(p => p.Email == email);
            if(user is not null)
            {
                task.DataCriacao = DateTime.Now;
                _context.Tasks.Add(task);
                _context.SaveChanges();  
                return new TaskDtoResponse(task);
            }
            return new TaskDtoResponse(erros: new List<string>{"Não foi possivel criar a tarefa, tente novamente"});
           
        }

        public List<TaskDtoResponse> BuscarTarefasEmail(string email)
        {
            var tarefas = _context.Tasks.Where(p => p.IdUsuario == email).OrderBy(p => p.Prioridade).Select(p => new TaskDtoResponse(p)).ToList();
            return tarefas;
        }

        public TaskDtoResponse AlterarTask(TaskDto dto, Guid taskId)
        {   
            var task = _context.Tasks.Find(taskId);
            if(task is null)
                return new TaskDtoResponse(erros: new List<string>{$"Não foi encontrada nenhuma task com id {taskId}"});
            
            task.MapearResponseTarefa(dto);
            _context.Tasks.Update(task);
            _context.SaveChanges();

            return new TaskDtoResponse(task);
        }

        public TaskDtoResponse DeletarTask(Guid taskId)
        {
            var task = _context.Tasks.Find(taskId);
            if(task is null)
                return new TaskDtoResponse(erros: new List<string>{$"Não foi encontrada nenhuma task com id {taskId}"});

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return new TaskDtoResponse(task);
        }
    }
}