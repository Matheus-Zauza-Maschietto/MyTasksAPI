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
 
        public TaskDto CriarTask(Tarefa task)
        {
            var user = _context.Users.FirstOrDefault(p => p.Email == task.IdUsuario);
            if(user is not null)
            {
                task.DataCriacao = DateTime.Now;

                _context.Tasks.Add(task);
                _context.SaveChanges();  
                return new TaskDto(task);
            }
            return new TaskDto();
           
        }

        public List<TaskDtoResponse> BuscarTarefasEmail(string email)
        {
            var tarefas = _context.Tasks.Where(p => p.IdUsuario == email).OrderBy(p => p.Prioridade).Select(p => new TaskDtoResponse(p)).ToList();
            return tarefas;
        }

        public bool AlterarTask(TaskDto dto, Guid taskId)
        {
            var task = _context.Tasks.Find(taskId);
            task.MapearResponseTarefa(dto);
            try{
                _context.Tasks.Update(task);
                _context.SaveChanges();
                return true;
            }
            catch{
                return false;
            }
        }

        public bool DeletarTask(Guid taskId)
        {
            try{
                var task = _context.Tasks.Find(taskId);
                _context.Tasks.Remove(task);
                _context.SaveChanges();
                return true;
            }
            catch{
                return false;
            }
        }
    }
}