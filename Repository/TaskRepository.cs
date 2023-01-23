using Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTasksAPI.Context;
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

        public string CriarTask(Tarefa task)
        {
            var user = _context.Users.Where(p => p.Email == task.IdUsuario);
            System.Console.WriteLine(user);
            if(user is not null)
            {
                task.DataCriacao = DateTime.Now;

                _context.Tasks.Add(task);
                _context.SaveChanges();  
                return "Usuario cadastrado com sucesso";
            }
            return "Usuario não encontrado";
           
        }
    }
}