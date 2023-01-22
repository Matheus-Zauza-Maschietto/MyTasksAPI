using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyTasksAPI.Context;

namespace MyTasksAPI.Repository
{
    public class TaskRepository
    {
        private readonly MyTaskContext _context;
        public TaskRepository(MyTaskContext context)
        {
            _context = context;
        }

        
    }
}