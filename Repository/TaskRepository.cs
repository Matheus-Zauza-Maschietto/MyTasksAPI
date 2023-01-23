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

        public void CriarTask(Tarefa task)
        {
            _context.Users.Where(p => p.Email == task.IdUsuario);
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
    }
}